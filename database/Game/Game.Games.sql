use Zeega;
go

create table Game.Games (
	Id int identity(1, 1) 
		constraint PK_Game_Id primary key
,	Name nvarchar(30) not null
,	ExternalId nvarchar(30) not null
,	Categories nvarchar(255) not null
,	Description nvarchar(1000)
,	ShortDescription nvarchar(255)
,	Instructions nvarchar(255)
,	Controls nvarchar(255)
,	Tags nvarchar(255)
,	Width int not null
,	Height int not null
,	SrcUri nvarchar(255) not null
,	SrcType int not null
,	IsSrcOnline bit default 1
,	Provider nvarchar(50) not null
,	ProviderUrl nvarchar(255) not null
,	ProviderGameUrl nvarchar(255)
,	Author nvarchar(50)
,	AuthorUrl nvarchar(255)
,	ZipUrl nvarchar(255)
,	IsZipDownloaded bit default 0
,	CreatedOn datetime not null
,	UpdatedOn datetime not null
);


exec sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contains games' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'Games'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Name',
								@name=N'MS_Description', @value=N'Represents game name', @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'Games'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'ExternalId',
								@name=N'MS_Description', @value=N'Represents game external ID' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'Games'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Categories',
								@name=N'MS_Description', @value=N'Game categories' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'Games'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Description',
								@name=N'MS_Description', @value=N'Game description' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'Games'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'ShortDescription',
								@name=N'MS_Description', @value=N'Game short description' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'Games'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Instructions',
								@name=N'MS_Description', @value=N'Game instructuons' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'Games'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Controls',
								@name=N'MS_Description', @value=N'Game controls' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'Games'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Tags',
								@name=N'MS_Description', @value=N'Game tags' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'Games'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Width',
								@name=N'MS_Description', @value=N'Game source width' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'Games'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Height',
								@name=N'MS_Description', @value=N'Game source height' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'Games'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'SrcUri',
								@name=N'MS_Description', @value=N'Game source URI' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'Games'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'SrcType',
								@name=N'MS_Description', @value=N'Game source type [1 - Swf, 2 - Html]' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'Games'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'IsSrcOnline',
								@name=N'MS_Description', @value=N'IsSourceOnline' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'Games'								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Provider',
								@name=N'MS_Description', @value=N'Game provider' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'Games'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'ProviderUrl',
								@name=N'MS_Description', @value=N'Game provider url' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'Games'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'ProviderGameUrl',
								@name=N'MS_Description', @value=N'Game provider url of game' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'Games'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Author',
								@name=N'MS_Description', @value=N'Game author' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'Games'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'AuthorUrl',
								@name=N'MS_Description', @value=N'Game author url' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'Games'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'ZipUrl',
								@name=N'MS_Description', @value=N'Game zip url' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'Games'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'IsZipDownloaded',
								@name=N'MS_Description', @value=N'Is zip downloaded' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'Games'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'CreatedOn',
								@name=N'MS_Description', @value=N'DateTime when game instance is created' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'Games'
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'UpdatedOn',
								@name=N'MS_Description', @value=N'DateTime when game instance is updated' , @level0type=N'SCHEMA',@level0name=N'Game', @level1type=N'TABLE',@level1name=N'Games'
go

