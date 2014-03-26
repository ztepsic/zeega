use Zeega;
go

create table Game.GameCategories (
	Id int identity(1, 1) 
		constraint PK_GameCat_Id primary key
,	Name nvarchar(30) not null
,	Slug nvarchar(60) not null
,	AppTenantId int not null
,	Sequence tinyint
,	Description nvarchar(1000)
,	ShortDescription nvarchar(255)
,	Keywords nvarchar(255)
	constraint FK_GameCat_AppTenantId
		foreign key (AppTenantId) references App.AppTenants(Id)
			on delete no action
			on update cascade
);

alter table Game.GameCategories
	add constraint UX_GameCat_Slug unique(AppTenantId, Slug);
go



exec sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Represents game category entity' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'GameCategories'
exec sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Game category name' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'GameCategories', @level2type=N'COLUMN',@level2name=N'Name'
exec sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Game category slug value' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'GameCategories', @level2type=N'COLUMN',@level2name=N'Slug'
exec sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Application tenant that owns this game category instance' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'GameCategories', @level2type=N'COLUMN',@level2name=N'AppTenantId'
exec sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Game category order' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'GameCategories', @level2type=N'COLUMN',@level2name=N'Sequence'
exec sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Full text description of the game category' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'GameCategories', @level2type=N'COLUMN',@level2name=N'Description'
exec sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Short text description of the game category' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'GameCategories', @level2type=N'COLUMN',@level2name=N'ShortDescription'
exec sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Keywords of the game category separated by commas' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'GameCategories', @level2type=N'COLUMN',@level2name=N'Keywords'
go