-- -------------------------------------------------------------------------------------------------
-- Create Schema
-- -------------------------------------------------------------------------------------------------
use master;
go


if exists (select name from master.dbo.sysdatabases where name = 'axado') begin
  exec msdb.dbo.sp_delete_database_backuphistory @database_name = N'axado';
  alter database axado set single_user with rollback immediate;
  drop database axado;
end
go

create database axado
  on primary (
    name = 'axado_data',
    filename = 'D:\database\mssql\data\axado.mdf',
    size = 10240KB,
    filegrowth = 20%
  )
  log on (
    name = 'axado_log',
    filename = 'D:\database\mssql\data\axado.ldf',
    size = 10240KB ,
    filegrowth = 20%
  );
go

alter database axado set recovery full;
alter database axado set multi_user;
alter database axado set read_write;
alter database axado set auto_create_statistics on;
alter database axado set auto_update_statistics on;
alter database axado set disable_broker;
alter database axado set page_verify checksum;
go


if not exists (select loginname from master.dbo.syslogins where name = 'usraxado') begin
  create login usraxado
  with
    password = 'aX4dO',
    default_database = axado,
    default_language = us_english,
    check_expiration = off,
    check_policy = off;
end
go



use axado;
go


if not exists (select name from sys.filegroups where is_default = 1 and name = N'PRIMARY')
  alter database axado modify filegroup [PRIMARY] default;
go

create user usraxado for login usraxado;
go

exec sp_addrolemember 'db_datareader', 'usraxado';
exec sp_addrolemember 'db_datawriter', 'usraxado';
go

grant execute on database::axado to usraxado;
go


create table [dbo].[__MigrationHistory] (
  MigrationId    nvarchar(150)  not null,
  ContextKey     nvarchar(300)  not null,
  Model          varbinary(max) not null,
  ProductVersion nvarchar(32)   not null,
  --
  constraint [PK_dbo.__MigrationHistory] 
    primary key (MigrationId, ContextKey)
);
go
