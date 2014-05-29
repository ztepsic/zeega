use Zeega;
go

create table Game.MediaResources (
	Id int identity(1, 1) 
		constraint PK_MediaRes_Id primary key
,	GameId int not null
,	Type int not null
,	ThumbSrcUri nvarchar(255) not null
,	ThumbSrcWidth int not null
,	ThumbSrcHeight int not null
,	SrcUri nvarchar(255) not null
,	SrcWidth int not null
,	SrcHeight int not null
,	Sequence smallint not null default 0
,	IsActive bit default 0
	constraint FK_MediaRes_GameId
		foreign key (GameId) references Game.Games(Id)
			on delete no action
			on update cascade
);

exec sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contains media resources',
								@level1type=N'TABLE',@level1name=N'MediaResources',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'GameId',
								@name=N'MS_Description', @value=N'Media resource for particular game',
								@level1type=N'TABLE',@level1name=N'MediaResources',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Type',
								@name=N'MS_Description', @value=N'Media resource type [1 - Thumbnail, 2 - Screenshot, 3 - Video]',
								@level1type=N'TABLE',@level1name=N'MediaResources',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'ThumbSrcUri',
								@name=N'MS_Description', @value=N'Thumbnail source URI',
								@level1type=N'TABLE',@level1name=N'MediaResources',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'ThumbSrcWidth',
								@name=N'MS_Description', @value=N'Thumbnail source width',
								@level1type=N'TABLE',@level1name=N'MediaResources',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'ThumbSrcHeight',
								@name=N'MS_Description', @value=N'Thumbnail source height',
								@level1type=N'TABLE',@level1name=N'MediaResources',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'SrcUri',
								@name=N'MS_Description', @value=N'Source URI',
								@level1type=N'TABLE',@level1name=N'MediaResources',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'SrcWidth',
								@name=N'MS_Description', @value=N'Source width',
								 @level1type=N'TABLE',@level1name=N'MediaResources',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'SrcHeight',
								@name=N'MS_Description', @value=N'Source height',
								@level1type=N'TABLE',@level1name=N'MediaResources',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'Sequence',
								@name=N'MS_Description', @value=N'Media resource sequence',
								@level1type=N'TABLE',@level1name=N'MediaResources',
								@level0type=N'SCHEMA',@level0name=N'Game'
								
exec sys.sp_addextendedproperty @level2type=N'COLUMN', @level2name=N'IsActive',
								@name=N'MS_Description', @value=N'Is media resource active',
								@level1type=N'TABLE',@level1name=N'MediaResources',
								@level0type=N'SCHEMA',@level0name=N'Game'
go

