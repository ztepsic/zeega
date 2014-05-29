use Zeega;
go

create table Game.Games (
	Id int identity(1, 1) 
		constraint PK_Game_Id primary key
,	Name nvarchar(30) not null
,	ExternalId nvarchar(30) not null
,	Description nvarchar(1000)
,	ShortDescription nvarchar(255)
,	Instructions nvarchar(255)
,	Controls nvarchar(255)
,	Width int not null
,	Height int not null
,	SrcUri nvarchar(255) not null
,	SrcType int not null
,	IsSrcOnline bit default 1
,	GameProviderId int not null
,	GameProviderGameUrl nvarchar(255)
,	Author nvarchar(50)
,	AuthorUrl nvarchar(255)
,	ZipUrl nvarchar(255)
,	IsZipDownloaded bit default 0
,	CreatedOn datetime not null
,	UpdatedOn datetime not null
	constraint FK_Games_GameProviderId
		foreign key (GameProviderId) references Game.GameProviders(Id)
			on delete no action
			on update cascade
);


exec sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contains games',
								@level1type=N'TABLE',@level1name=N'Games',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Name',
								@name=N'MS_Description', @value=N'Represents game name',
								@level1type=N'TABLE',@level1name=N'Games',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'ExternalId',
								@name=N'MS_Description', @value=N'Represents game external ID',
								@level1type=N'TABLE',@level1name=N'Games',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Description',
								@name=N'MS_Description', @value=N'Game description',
								@level1type=N'TABLE',@level1name=N'Games',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'ShortDescription',
								@name=N'MS_Description', @value=N'Game short description',
								@level1type=N'TABLE',@level1name=N'Games',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Instructions',
								@name=N'MS_Description', @value=N'Game instructuons',
								@level1type=N'TABLE',@level1name=N'Games',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Controls',
								@name=N'MS_Description', @value=N'Game controls',
								@level1type=N'TABLE',@level1name=N'Games',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Width',
								@name=N'MS_Description', @value=N'Game source width',
								@level1type=N'TABLE',@level1name=N'Games',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Height',
								@name=N'MS_Description', @value=N'Game source height',
								@level1type=N'TABLE',@level1name=N'Games',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'SrcUri',
								@name=N'MS_Description', @value=N'Game source URI',
								@level1type=N'TABLE',@level1name=N'Games',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'SrcType',
								@name=N'MS_Description', @value=N'Game source type [1 - Swf, 2 - Html]',
								@level1type=N'TABLE',@level1name=N'Games',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'IsSrcOnline',
								@name=N'MS_Description', @value=N'IsSourceOnline',
								@level1type=N'TABLE',@level1name=N'Games',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'GameProviderId',
								@name=N'MS_Description', @value=N'Game provider Id',
								@level1type=N'TABLE',@level1name=N'Games',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'GameProviderGameUrl',
								@name=N'MS_Description', @value=N'Game provider game url',
								@level1type=N'TABLE',@level1name=N'Games',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Author',
								@name=N'MS_Description', @value=N'Game author',
								@level1type=N'TABLE',@level1name=N'Games',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'AuthorUrl',
								@name=N'MS_Description', @value=N'Game author url',
								@level1type=N'TABLE',@level1name=N'Games',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'ZipUrl',
								@name=N'MS_Description', @value=N'Game zip url',
								@level1type=N'TABLE',@level1name=N'Games',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'IsZipDownloaded',
								@name=N'MS_Description', @value=N'Is zip downloaded',
								@level1type=N'TABLE',@level1name=N'Games',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'CreatedOn',
								@name=N'MS_Description', @value=N'DateTime when game instance is created',
								@level1type=N'TABLE',@level1name=N'Games',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'UpdatedOn',
								@name=N'MS_Description', @value=N'DateTime when game instance is updated',
								@level1type=N'TABLE',@level1name=N'Games',
								@level0type=N'SCHEMA',@level0name=N'Game'
go

