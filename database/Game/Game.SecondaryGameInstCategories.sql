use Zeega;
go

create table Game.SecondaryGameInstCategories (
	Id int identity(1, 1) 
		constraint PK_SecGameInstCat_Id primary key
,	GameInstanceId int not null
,	GameCategoryId int not null
	constraint FK_SecGameInstCat_GameInstanceId
		foreign key (GameInstanceId) references Game.GameInstances(Id)
			on delete no action
			on update cascade
,	constraint FK_SecGameInstCat_GameCategoryId
		foreign key (GameCategoryId) references Game.GameCategories(Id)
			on delete no action
			on update no action
);

exec sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Relation between game instances and game categories' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'SecondaryGameInstCategories'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'GameInstanceId',
								@name=N'MS_Description', @value=N'Game instance id', @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'SecondaryGameInstCategories'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'GameCategoryId',
								@name=N'MS_Description', @value=N'Game category id', @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'SecondaryGameInstCategories'
go

