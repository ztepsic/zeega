use Zeega;
go

create table Game.GameInstances (
	Id int identity(1, 1) 
		constraint PK_GameInst_Id primary key
,	AppTenantId int not null
,	GameId int not null
,	Name nvarchar(30) not null
,	Slug nvarchar(100) not null
,	PrimaryGameCategoryId int not null
,	Description nvarchar(1000)
,	ShortDescription nvarchar(255)
,	Instructions nvarchar(255)
,	Controls nvarchar(255)
,	IsPublished bit not null default 0
,	CreatedOn datetime not null
,	UpdatedOn datetime not null
	constraint FK_GameInst_AppTenantId
		foreign key (AppTenantId) references App.AppTenants(Id)
			on delete no action
			on update cascade
,	constraint FK_GameInst_PrimaryGameCategoryId
		foreign key (PrimaryGameCategoryId) references Game.GameCategories(Id)
			on delete no action
			on update no action
,	constraint FK_GameInst_GameId
		foreign key (GameId) references Game.Games(Id)
			on delete no action
			on update cascade
);

exec sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contains game instances' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'GameInstances'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'AppTenantId',
								@name=N'MS_Description', @value=N'Represents application tenant to whom game instance belongs', @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'GameInstances'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Name',
								@name=N'MS_Description', @value=N'Represents game instance name', @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'GameInstances'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Slug',
								@name=N'MS_Description', @value=N'Represents game instance slug' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'GameInstances'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'PrimaryGameCategoryId',
								@name=N'MS_Description', @value=N'Represents game instance primary game category' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'GameInstances'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Description',
								@name=N'MS_Description', @value=N'Game description' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'GameInstances'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'ShortDescription',
								@name=N'MS_Description', @value=N'Game short description' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'GameInstances'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Instructions',
								@name=N'MS_Description', @value=N'Game instructuons' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'GameInstances'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Controls',
								@name=N'MS_Description', @value=N'Game controls' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'GameInstances'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'IsPublished',
								@name=N'MS_Description', @value=N'Is game instance published' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'GameInstances'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'CreatedOn',
								@name=N'MS_Description', @value=N'DateTime when game instance is created' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'GameInstances'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'UpdatedOn',
								@name=N'MS_Description', @value=N'DateTime when game instance is updated' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'GameInstances'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'GameId',
								@name=N'MS_Description', @value=N'Game instance of particular game' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'GameInstances'
go

