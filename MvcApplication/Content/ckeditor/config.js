/*
Copyright (c) 2003-2012, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function (config) {
    config.toolbar = 'MyToolbar';

    config.toolbar_MyToolbar =
	[
		{ name: 'styles', items: ['Styles', 'Format', 'Font', 'FontSize'] },
		{ name: 'basicstyles', items: ['Bold', 'Italic'] },
	    { name: 'insert', items : [ 'Image' ] },
		{ name: 'paragraph', items: ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent'] },
		{ name: 'links', items: ['Link', 'Unlink', 'Anchor'] },
		{ name: 'tools', items: ['Maximize'] },
	    { name: 'document', items: ['Source'] }
	];
};