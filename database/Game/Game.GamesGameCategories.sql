use Zeega;
go

if(exists(select table_name
		  from INFORMATION_SCHEMA.TABLES
		  where TABLE_SCHEMA = 'Game'
		  and	TABLE_NAME = 'GamesGameCategories')
)
	drop table Game.GamesGameCategories;
go

create table Game.GamesGameCategories (
	Id int identity(1, 1) 
		constraint PK_GamesGameCat_Id primary key
,	GameId int not null
,	GameCategoryId int not null
	constraint FK_GamesGameCat_GameId
		foreign key (GameId) references Game.Games(Id)
			on delete no action
			on update cascade
,	constraint FK_GamesGameCat_GameCategoryId
		foreign key (GameCategoryId) references Game.GameCategories(Id)
			on delete no action
			on update no action
);

alter table Game.GamesGameCategories
	add constraint UX_GamesGameCategories_GameIdGameCatId unique(GameId, GameCategoryId);
go

exec sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Games to GameCategories replations',
								@level1type=N'TABLE',@level1name=N'GamesGameCategories',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'GameId',
								@name=N'MS_Description', @value=N'Game id',
								@level1type=N'TABLE',@level1name=N'GamesGameCategories',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'GameCategoryId',
								@name=N'MS_Description', @value=N'Game category id',
								@level1type=N'TABLE',@level1name=N'GamesGameCategories',
								@level0type=N'SCHEMA',@level0name=N'Game'
go

