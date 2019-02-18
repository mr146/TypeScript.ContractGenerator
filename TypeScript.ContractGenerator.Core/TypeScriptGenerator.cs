using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

using SKBKontur.Catalogue.TypeScript.CodeDom;
using SKBKontur.Catalogue.TypeScript.ContractGenerator.Core.Internals;
using SKBKontur.Catalogue.TypeScript.ContractGenerator.Core.TypeBuilders;

namespace SKBKontur.Catalogue.TypeScript.ContractGenerator.Core
{
    public class TypeScriptGenerator : ITypeGenerator
    {
        public TypeScriptGenerator(ICustomTypeGenerator customTypeGenerator, Type[] rootTypes)
        {
            this.rootTypes = rootTypes;
            TypeScriptUnitFactory = new DefaultTypeScriptGeneratorOutput();
            this.customTypeGenerator = customTypeGenerator ?? new NullCustomTypeGenerator();
            TypeScriptDeclarations = new Dictionary<Type, ITypeBuildingContext>();
        }

        public TypeScriptUnit[] Generate()
        {
            foreach(var type in rootTypes)
                RequestTypeBuild(type);
            while(TypeScriptDeclarations.Values.Any(x => !x.IsDefinitionBuilded))
            {
                foreach(var currentType in TypeScriptDeclarations.ToArray())
                {
                    if(!currentType.Value.IsDefinitionBuilded)
                        currentType.Value.BuildDefinition(this);
                }
            }

            return TypeScriptUnitFactory.Units;
        }

        public void GenerateFiles(string targetPath)
        {
            foreach(var type in rootTypes)
                RequestTypeBuild(type);
            while(TypeScriptDeclarations.Values.Any(x => !x.IsDefinitionBuilded))
            {
                foreach(var currentType in TypeScriptDeclarations.ToArray())
                {
                    if(!currentType.Value.IsDefinitionBuilded)
                        currentType.Value.BuildDefinition(this);
                }
            }

            FilesGenerator.GenerateFiles(targetPath, TypeScriptUnitFactory);
        }

        public void GenerateTypeScriptFiles(string targetPath)
        {
            foreach(var type in rootTypes)
                RequestTypeBuild(type);
            while(TypeScriptDeclarations.Values.Any(x => !x.IsDefinitionBuilded))
            {
                foreach(var currentType in TypeScriptDeclarations.ToArray())
                {
                    if(!currentType.Value.IsDefinitionBuilded)
                        currentType.Value.BuildDefinition(this);
                }
            }

            FilesGenerator.GenerateTypeScriptFiles(targetPath, TypeScriptUnitFactory);
        }

        private void RequestTypeBuild(Type type)
        {
            ResolveType(type);
        }

        public ITypeBuildingContext ResolveType(Type type)
        {
            if(TypeScriptDeclarations.ContainsKey(type))
            {
                return TypeScriptDeclarations[type];
            }

            var typeLocation = customTypeGenerator.GetTypeLocation(type);
            var typeBuildingContext = customTypeGenerator.ResolveType(typeLocation, type, TypeScriptUnitFactory);
            if(typeBuildingContext == null)
            {
                if(BuildInTypeBuildingContext.Accept(type))
                {
                    typeBuildingContext = new BuildInTypeBuildingContext(type);
                }

                if(type.IsArray)
                {
                    typeBuildingContext = new ArrayTypeBuildingContext(type.GetElementType());
                }

                if(type.IsEnum)
                {
                    var targetUnit = TypeScriptUnitFactory.GetOrCreateTypeUnit(typeLocation);
                    typeBuildingContext = new EnumTypeBuildingContextImpl(targetUnit, type);
                }

                if(typeBuildingContext == null)
                {

                    var targetUnit = TypeScriptUnitFactory.GetOrCreateTypeUnit(typeLocation);
                    typeBuildingContext = new CustomTypeTypeBuildingContextImpl(targetUnit, type);
                }
            }

            typeBuildingContext.Initialize(this);
            TypeScriptDeclarations.Add(type, typeBuildingContext);
            return typeBuildingContext;
        }

        public TypeScriptType BuildAndImportType(TypeScriptUnit targetUnit, ICustomAttributeProvider attributeProvider, Type type, bool notNull = false)
        {
            if(type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                var un = GetTypeScriptType(targetUnit, type.GetGenericArguments()[0]);
                return new TypeScriptNullableType(un);
            }

            if(type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Task<>))
            {
                return GetTypeScriptType(targetUnit, type.GetGenericArguments()[0]);
            }

            if(type == typeof(Task))
            {
                return new TypeScriptVoidType();
            }

            var result = GetTypeScriptType(targetUnit, type);
            if(attributeProvider != null && IsNullable(attributeProvider, type) && !notNull)
                result = new TypeScriptNullableType(result);

            return result;
        }

        private TypeScriptType GetTypeScriptType(TypeScriptUnit targetUnit, Type type)
        {
            if(TypeScriptDeclarations.ContainsKey(type))
                return TypeScriptDeclarations[type].ReferenceFrom(targetUnit, this);
            if(type.IsGenericTypeDefinition && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                return new TypeScriptNullableType(GetTypeScriptType(targetUnit, type.GetGenericArguments()[0]));
            var context = ResolveType(type);
            return context.ReferenceFrom(targetUnit, this);
        }

        private static bool IsNullable(ICustomAttributeProvider attributeContainer, Type type)
        {
            return type.IsClass && GetCustomAttributes(attributeContainer).All(x => x.GetType().Name != "RequiredAttribute")
                                && GetCustomAttributes(attributeContainer).All(x => x.GetType().Name != "NotNullAttribute");
        }

        private static object[] GetCustomAttributes(ICustomAttributeProvider attributeContainer)
        {
            var memberInfo = attributeContainer as MemberInfo;
            if(memberInfo != null)
            {
                return Attribute.GetCustomAttributes(memberInfo).Cast<object>().ToArray();
            }

            return attributeContainer.GetCustomAttributes(true);
        }

        private readonly Type[] rootTypes;
        private readonly DefaultTypeScriptGeneratorOutput TypeScriptUnitFactory;
        private readonly ICustomTypeGenerator customTypeGenerator;
        private readonly Dictionary<Type, ITypeBuildingContext> TypeScriptDeclarations;
    }
}