use Zeega;
go

if(exists(select table_name
		  from INFORMATION_SCHEMA.TABLES
		  where TABLE_SCHEMA = 'Game'
		  and	TABLE_NAME = 'GameCatToGameInstCatMapping')
)
	drop table Game.GameCatToGameInstCatMapping;
go

create table Game.GameCatToGameInstCatMapping (
	Id int identity(1, 1) 
		constraint PK_GameCatToGameCatMapping_Id primary key
,	GameCategoryId int not null
,	GameInstanceCategoryId int not null
,	constraint FK_GameCatToGameCatMapping_GameCategoryId
		foreign key (GameCategoryId) references Game.GameCategories(Id)
			on delete cascade
			on update cascade
,	constraint FK_GameCatToGameCatMapping_GameInstanceCategoryId
		foreign key (GameInstanceCategoryId) references Game.GameInstanceCategories(Id)
			on delete cascade
			on update cascade
);

alter table Game.GameCatToGameInstCatMapping
	add constraint UX_GameCatToGameCatMapping_GameCatId_GameInstCatId unique(GameCategoryId, GameInstanceCategoryId);
go



exec sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Game category to game instance category mappings',
								@level1type=N'TABLE', @level1name=N'GameCatToGameInstCatMapping',
								@level0type=N'SCHEMA',@level0name=N'Game'

go