using System;
using System.Runtime.Serialization;

namespace EmployeeDirectoryProcessor.Model
{
    public enum UserType
    {
        [EnumMember]
        Employee,
        [EnumMember]
        Editor,
        [EnumMember]
        Viewer
    }

}
