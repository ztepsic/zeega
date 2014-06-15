use Zeega;
go

if(exists(select table_name
		  from INFORMATION_SCHEMA.TABLES
		  where TABLE_SCHEMA = 'Game'
		  and	TABLE_NAME = 'GamesTags')
)
	drop table Game.GamesTags;
go

create table Game.GamesTags (
	Id int identity(1, 1) 
		constraint PK_GamesTag_Id primary key
,	GameId int not null
,	TagId int not null
	constraint FK_GamesTag_GameId
		foreign key (GameId) references Game.Games(Id)
			on delete no action
			on update cascade
,	constraint FK_GamesTag_TagId
		foreign key (TagId) references Tags(Id)
			on delete no action
			on update no action
);

alter table Game.GamesTags
	add constraint UX_GamesTag_GameIdTagId unique(GameId, TagId);
go


exec sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Games to tags replations',
								@level1type=N'TABLE',@level1name=N'GamesTags',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'GameId',
								@name=N'MS_Description', @value=N'Game id',
								@level1type=N'TABLE',@level1name=N'GamesTags',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'TagId',
								@name=N'MS_Description', @value=N'Tag id',
								@level1type=N'TABLE',@level1name=N'GamesTags',
								@level0type=N'SCHEMA',@level0name=N'Game'
go

