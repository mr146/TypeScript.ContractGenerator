
export type GenericContainingRootType = {
    genericIntChild?: null | GenericChildType<number>;
    genericNullableIntChild?: null | GenericChildType<null | number>;
    arrayGenericNullableIntChild?: null | GenericChildType<null | number>[];
    severalGenericParameters?: null | ChildWithSeveralGenericParameters<string, number>;
    genericChildType?: null | GenericChildType<ChildWithConstraint<string>>;
    genericHell?: null | GenericChildType<ChildWithConstraint<GenericChildType<string>>>;
};
export type GenericChildType<T> = {
    childType?: T;
    childTypes?: null | T[];
};
export type ChildWithSeveralGenericParameters<T1, T2> = {
    item1?: T1;
    item2?: T2;
};
export type ChildWithConstraint<T> = {
    child?: T;
};
