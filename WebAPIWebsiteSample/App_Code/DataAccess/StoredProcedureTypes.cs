﻿/// <summary>
/// Used with StorageMapping to indentify data access object needed (Stored procedure name if SQL Server is used)
/// </summary>
public enum StoredProcedureTypes
{
    List,
    Insert,
    Update,
    Delete,
    ById
}