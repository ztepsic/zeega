use Zeega;
go

create table Game.GameInstancesTags (
	Id int identity(1, 1) 
		constraint PK_GameInstTag_Id primary key
,	GameInstanceId int not null
,	TagId int not null
	constraint FK_GameInstTag_GameInstanceId
		foreign key (GameInstanceId) references Game.GameInstances(Id)
			on delete no action
			on update cascade
,	constraint FK_GameInstTag_TagId
		foreign key (TagId) references dbo.Tags(Id)
			on delete no action
			on update no action
);

exec sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Relation between game instances and tags',
								@level1type=N'TABLE', @level1name=N'GameInstancesTags',
								@level0type=N'SCHEMA', @level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'GameInstanceId',
								@name=N'MS_Description', @value=N'Game instance id',
								@level1type=N'TABLE',@level1name=N'GameInstancesTags',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'TagId',
								@name=N'MS_Description', @value=N'Tag id',
								@level1type=N'TABLE',@level1name=N'GameInstancesTags',
								@level0type=N'SCHEMA',@level0name=N'Game'
go

