using System;
using System.Collections.Generic;

namespace Il2CppDumper
{
    public class GenTypeInfo
    {
        public int Id;
        public string Image;
        public int ByValType;
        public int ByRefType;
        public int DeclaringType;
        public int ParentType;
        public int ElementType;
        public uint Flags;
        public uint Bitfield;
        public List<int> Interfaces = new();
        public string Namespace;
        public string TypeName;
        public string[] GenericParameters = Array.Empty<string>();
        public List<GenFieldInfo> Fields = new();
        public List<GenFieldInfo> StaticFields = new();
        public List<GenFieldInfo> ConstFields = new();
        public List<GenVTableMethodInfo> VTableMethods = new();
        public List<GenRGCTXInfo> RGCTXs = new();
    }

    public class GenFieldInfo
    {
        public int Offset = -1;
        public int FieldType;
        public string FieldName;
        public string DefaultValue;
    }

    public class GenVTableMethodInfo
    {
        public string MethodName;
    }

    public class GenRGCTXInfo
    {
        public Il2CppRGCTXDataType Type;
        public string TypeName;
        public string ClassName;
        public string MethodName;
    }

    public class GenType
    {
        private static int Count;
        public int Id;
        public int InternalId;
        public ExtendedGenType ExtendedType;
        public uint Attributes;
        public Il2CppTypeEnum Type;
        public uint NumMods;
        public bool ByRef;
        public bool Pinned;
        public bool ValueType;

        public GenType(Il2CppExecutor executor, Il2CppType type)
        {
            Id = Count++;
            InternalId = executor.GetInternalId(type);
            ExtendedType = executor.GetExtendedTypeInformation(type);
            Attributes = type.attrs;
            Type = type.type;
            NumMods = type.num_mods;
            ByRef = type.byref != 0;
            Pinned = type.pinned != 0;
            ValueType = type.valuetype != 0;
        }
    }

    public class ExtendedGenType
    {
        public byte ArrayRank;
        public byte ArrayLoBoundCount;
        public ulong ArrayLoBounds;
        public byte ArraySizeCount;
        public ulong ArraySizes;
        public string GenericParamName;
        public int[] GenericTypes;
    }
}
