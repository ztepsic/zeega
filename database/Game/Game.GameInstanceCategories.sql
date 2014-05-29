use Zeega;
go

if(exists(select table_name
		  from INFORMATION_SCHEMA.TABLES
		  where TABLE_SCHEMA = 'Game'
		  and	TABLE_NAME = 'GameInstanceCategories')
)
	drop table Game.GameInstanceCategories;
go

create table Game.GameInstanceCategories (
	Id int identity(1, 1) 
		constraint PK_GameInstCat_Id primary key
,	Name nvarchar(30) not null
,	Slug nvarchar(60) not null
,	AppTenantId int not null
,	Sequence tinyint
,	Description nvarchar(1000)
,	ShortDescription nvarchar(255)
,	Keywords nvarchar(255)
	constraint FK_GameInstCat_AppTenantId
		foreign key (AppTenantId) references App.AppTenants(Id)
			on delete no action
			on update cascade
);

alter table Game.GameInstanceCategories
	add constraint UX_GameInstCat_Slug unique(AppTenantId, Slug);
go



exec sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contains game categories',
								@level1type=N'TABLE', @level1name=N'GameInstanceCategories',
								@level0type=N'SCHEMA', @level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Name',
								@name=N'MS_Description', @value=N'Game category name',
								@level1type=N'TABLE', @level1name=N'GameInstanceCategories',
								@level0type=N'SCHEMA', @level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Slug',
								@name=N'MS_Description', @value=N'Game category slug value',
								@level1type=N'TABLE', @level1name=N'GameInstanceCategories',
								@level0type=N'SCHEMA', @level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'AppTenantId',
								@name=N'MS_Description', @value=N'Application tenant that owns this game category instance',
								@level1type=N'TABLE', @level1name=N'GameInstanceCategories',
								@level0type=N'SCHEMA', @level0name=N'Game'
								
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Sequence',
								@name=N'MS_Description', @value=N'Game category order',
								@level1type=N'TABLE', @level1name=N'GameInstanceCategories',
								@level0type=N'SCHEMA', @level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Description',
								@name=N'MS_Description', @value=N'Full text description of the game category',
								@level1type=N'TABLE', @level1name=N'GameInstanceCategories',
								@level0type=N'SCHEMA', @level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'ShortDescription',
								@name=N'MS_Description', @value=N'Short text description of the game category',
								@level1type=N'TABLE', @level1name=N'GameInstanceCategories',
								@level0type=N'SCHEMA', @level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Keywords',
								@name=N'MS_Description', @value=N'Keywords of the game category separated by commas',
								@level1type=N'TABLE', @level1name=N'GameInstanceCategories',
								@level0type=N'SCHEMA', @level0name=N'Game'
go