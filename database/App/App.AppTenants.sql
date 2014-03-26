use Zeega;
go

create table App.AppTenants (
	Id int identity(1, 1)
		constraint PK_AppTenant_Id primary key
,	Name nvarchar(30) not null
,	LanguageCode nvarchar(2) not null
,	Description nvarchar(100)
,	IsPrimary bit not null default 0
);
go

exec sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Application tenant name' , @level0type=N'SCHEMA',@level0name=N'App', @level1type=N'TABLE',@level1name=N'AppTenants', @level2type=N'COLUMN',@level2name=N'Name'
exec sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Two letter language code (ISO 639-1) of the application tenant
E.g. en, de, hr' , @level0type=N'SCHEMA',@level0name=N'App', @level1type=N'TABLE',@level1name=N'AppTenants', @level2type=N'COLUMN',@level2name=N'LanguageCode'
exec sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Application tenant description' , @level0type=N'SCHEMA',@level0name=N'App', @level1type=N'TABLE',@level1name=N'AppTenants', @level2type=N'COLUMN',@level2name=N'Description'
exec sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Value that indicates the primary application tenant' , @level0type=N'SCHEMA',@level0name=N'App', @level1type=N'TABLE',@level1name=N'AppTenants', @level2type=N'COLUMN',@level2name=N'IsPrimary'
exec sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Represents application''s tenant in multitenant environement' , @level0type=N'SCHEMA',@level0name=N'App', @level1type=N'TABLE',@level1name=N'AppTenants'
go