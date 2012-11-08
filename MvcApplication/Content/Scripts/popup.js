(function ($) {
    $.fn.extend({
        center: function () {
            return this.each(function () {
                var top = ($(window).height() - $(this).outerHeight()) / 2;
                var left = ($(window).width() - $(this).outerWidth()) / 2;
                $(this).css({ position: 'fixed', margin: 0, top: (top > 0 ? top : 0) + 'px', left: (left > 0 ? left : 0) + 'px' });
            });
        }
    });
})(jQuery);

(function ($) {
    var instances = new Array();
    var prefixId = "#";
    var dialogPostfix = 'contentDialog';
    var overlayPostfix = 'Overlay';
    var dialogContentEvents = '.dialogContentEvents';
    var dialogContentCreateString = '<div class="stbr-dialog" id="{#dialogId#}" style="width:{#width#}px;z-index:{#zindex#}">' +
		'<div class="leftcorner">' +
			'<div class="rightcorner">' +
				'<div class="titlebar">' +
					'<span class="titleText">{#title#}</span><a href="javascript:void(0);" class="close"></a></div>' +
			'</div>' +
		'</div>' +
		'<div class="wndHolder">' +
			'<div class="wndLeftBorder">' +
				'<div class="wndRightBorder">' +
					'<div class="wndMC">' +
						'<div class="wndBody">' +
							'<div class="wndNoBorder">' +
								'<div class="wndPanelBwrap">' +
									'<div class="wndContent" style="height:{#height#}px; padding:{#padding#}px">' +
										'{#content#}' +
									'</div>' +
								'</div>' +
							'</div>' +
						'</div>' +
					'</div>' +
				'</div>' +
			'</div>' +
			'<div class="popup-footer">' +
				'<div class="footerBr">' +
					'<div class="footerBc">' +
					'</div>' +
				'</div>' +
			'</div>' +
			'<div class="dragShadow">' +
			'</div>' +
		'</div>' +
	'</div>' +
	'<div id="{#dialogId#}Overlay" class="stbr-overlay" style="z-index:{#zindex-1#}">' +
	'</div>';

    var dialogFrameCreateString = '<div class="stbr-dialog" id="{#dialogId#}" style="width:{#width#}px">' +
    '<div class="leftcorner">' +
        '<div class="rightcorner">' +
            '<div class="titlebar">' +
                '<span class="titleText">{#title#}</span><a href="javascript:void(0);" class="close"></a></div>' +
        '</div>' +
    '</div>' +
    '<div class="wndHolder">' +
        '<div class="wndLeftBorder">' +
            '<div class="wndRightBorder">' +
                '<div class="wndMC">' +
                    '<div class="wndBody">' +
                        '<div class="wndNoBorder">' +
                            '<div class="wndPanelBwrap">' +
                                '<div class="wndContent" style="height:{#height#}px; padding:{#padding#}px">' +
                                    '<iframe  frame id="{#dialogId#}Frame" name="{#dialogId#}Frame" src={#url#} frameborder="{#frameBorder#}" scrolling="{#frameScroll#}" width="{#frameWidth#}" height="{#frameHeight#}"/>' +
                                '</div>' +
                            '</div>' +
                        '</div>' +
                    '</div>' +
                '</div>' +
            '</div>' +
        '</div>' +
        '<div class="popup-footer">' +
            '<div class="footerBr">' +
                '<div class="footerBc">' +
                '</div>' +
            '</div>' +
        '</div>' +
        '<div class="dragShadow">' +
        '</div>' +
    '</div>' +
'</div>' +
'<div id="{#dialogId#}Overlay" class="stbr-overlay">' +
'</div>';
    function __validateNullUndefined(object) {
        if (typeof (object) == "undefined" || object == null) {
            return false;
        }
        return true;
    }

    function __indexInArray(dialog) {
        for (var i = 0; i < instances.length; i++) {
            if (instances[i].dialogId == dialog.dialogId) {
                return i;
            }
        }
        return null;
    }

    function __getDialogObjectFromElement(domElement) {
        if ($(domElement).hasClass('stbr-dialog')) {
            var id = $(domElement).attr("id");
            for (var i = 0; i < instances.length; i++) {
                if (id == instances[i].dialogId) {
                    return instances[i];
                }
            }
        } else {
            return __getDialogObjectFromElement($(domElement).parent().get(0));
        }
        return null;
    }

    function __closeButtonClick() {
        var dialog = __getDialogObjectFromElement(this);
        if (__validateNullUndefined(dialog)) {
            if (__validateNullUndefined(dialog.onClose)) {
                if (dialog.onClose()) {
                    dialog.destroy();
                }
            } else {
                dialog.destroy();
            }
        }
    }

    function __extendSettingsForDialogContent(initOptions) {
        initOptions = $.extend({
            width: 500,
            height: 500,
            title: 'Please set the title',
            isModal: true,
            bindPublicEventsArray: new Array(),
            content: '',
            onClose: null,
            padding: 5,
            zindex: 1002
        }, initOptions);
        return initOptions;
    }
    function __extendSettingsForDialogFrame(initOptions) {
        initOptions = $.extend({
            width: 500,
            height: 500,
            title: 'Please set the title',
            isModal: true,
            bindPublicEventsArray: new Array(),
            url: '',
            padding: 5,
            zindex: 1002,
            frameScroll: 'no',
            frameBorder: '0',
            frameWidth: "100%",
            frameHeight: "100%",
            onClose: null
        }, initOptions);
        return initOptions;
    }

    //-----------------------------------------------------------------------------------------------------------------------
    function BaseDialog(width, height, title, isModal, bindPublicEventsArray, onClose, padding, zindex) {
        this.width = width;
        this.height = height;
        this.title = title;
        this.isModal = isModal;
        this.bindPublicEventsArray = bindPublicEventsArray;
        this.dialogId = Math.round((Math.random() * 1000)).toString() + dialogPostfix;
        this.onClose = onClose;
        this.padding = padding;
        this.zindex = zindex;
    }

    BaseDialog.prototype.hide = function () {
        if (this.isModal) {
            $(prefixId + this.dialogId + overlayPostfix).hide();
        }
        $(prefixId + this.dialogId).hide();
    };

    BaseDialog.prototype.show = function () {
        if (this.isModal) {
            $(prefixId + this.dialogId + overlayPostfix).show();
        }
        $(prefixId + this.dialogId).show();
    };


    BaseDialog.prototype.makeDraggable = function () {
        var $dialogDom = $(prefixId + this.dialogId);
        var self = this;
        $dialogDom.draggable({
            containment: 'document',
            handle: 'titlebar',
            scroll: true,
            cancel: '.wndHolder,.close',
            start: function (event, ui) {
                $dialogDom.css('opacity', 0.65);
                $dialogDom.find('.wndLeftBorder').hide().end().find('popup-footer').hide().end().find('.dragShadow').css("height", (self.height + $dialogDom.find('.popup-footer').outerHeight() * 2 + 4) + "px").show();
            },
            stop: function (event, ui) {
                $dialogDom.css('opacity', 1).find('.wndLeftBorder').show().end().find('.popup-footer').show().end().find('.dragShadow').hide();
            }
        });
    };
    BaseDialog.prototype.bindPrivateEvents = function () {
        var $titleBar = $(prefixId + this.dialogId).find(".titlebar");
        $titleBar.find('a.close').bind('click.stansberryPopup', __closeButtonClick);
    };
    BaseDialog.prototype.destroyEvents = function () {
        var $dialog = $(prefixId + this.dialogId);
        $dialog.find(".titlebar").unbind('.stansberryPopup');
        $dialog.find("a.close").unbind('.stansberryPopup');
        $dialog.draggable('destroy');
    };
    BaseDialog.prototype.destroy = function () {
        BaseDialog.prototype.destroyEvents.call(this);
        var $dialog = $(prefixId + this.dialogId);
        if (instances.length == 1) {
            var index = __indexInArray(this);
            if (__validateNullUndefined(index)) {
                instances.splice(index, 1);
            }
        }
        $dialog.remove();
        $(prefixId + this.dialogId + overlayPostfix).remove();
    };
    BaseDialog.prototype.toCenter = function () {
        var $dialog = $(prefixId + this.dialogId);
        $dialog.center();
    };
    //----------------------------------------------------------------------------------------------------------------------
    function DialogContent(width, height, title, isModal, content, onClose, padding, zindex, bindEventsArray) {
        BaseDialog.call(this, width, height, title, isModal, bindEventsArray, onClose, padding, zindex);
        this.content = content;
    }

    DialogContent.prototype = new BaseDialog();
    delete DialogContent.prototype.width;
    delete DialogContent.prototype.height;
    delete DialogContent.prototype.bindPublicEventsArray;
    delete DialogContent.prototype.title;
    delete DialogContent.prototype.dialogId;
    delete DialogContent.prototype.state;
    delete DialogContent.prototype.onClose;
    delete DialogContent.prototype.isModal;
    delete DialogContent.prototype.destroy;
    DialogContent.prototype.constructor = DialogContent;

    DialogContent.prototype.getContent = function () {
        return this.content;
    };
    DialogContent.prototype.bindPublicEvents = function () {
        if (__validateNullUndefined(this.bindPublicEventsArray)) {
            if (this.bindPublicEventsArray.length > 0) {
                var $dialogContent = $(prefixId + this.dialogId).find('div.wndContent');
                for (var i = 0; i < this.bindPublicEventsArray.length; i++) {
                    $dialogContent.find(this.bindPublicEventsArray[i].elementIdOrTag).bind(this.bindPublicEventsArray[i].eventName + dialogContentEvents, this.bindPublicEventsArray[i].func);
                }
            }
        }
    };
    DialogContent.prototype.bindTo = function (delegateObject) {
        if (this.state) {
            var $dialogContent = $(prefixId + this.dialogId).find('div.wndContent');
            $dialogContent.find(delegateObject.elementIdOrTag).bind(delegateObject.eventName + dialogContentEvents, delegateObject.delegateFunc);
        }
    };
    DialogContent.prototype.setContent = function (value) {
        if (this.state) {
            $(prefixId + this.dialogId).find(".wndContent").html(value);
        }
        this.content = value;
    };
    DialogContent.prototype.destroy = function () {
        var $dialogContent = $(prefixId + this.dialogId).find('div.wndContent');
        $dialogContent.contents().each(function () {
            $(this).unbind('.dialogContentEvents');
        });
        BaseDialog.prototype.destroy.call(this);
    };
    //----------------------------------------------------------------------------------------------------------------------------

    function DialogFrame(width, height, title, isModal, url, frameScroll, frameWidth, frameHeight, frameBorder, bindEventsArray, onClose, padding) {
        BaseDialog.call(this, width, height, title, isModal, bindEventsArray, onClose, padding);
        this.frameScroll = frameScroll;
        this.url = url;
        this.frameWidth = frameWidth;
        this.frameHeight = frameHeight;
        this.frameBorder = frameBorder;
    }
    DialogFrame.prototype = new BaseDialog();
    delete DialogContent.prototype.width;
    delete DialogContent.prototype.height;
    delete DialogContent.prototype.bindPublicEventsArray;
    delete DialogContent.prototype.title;
    delete DialogContent.prototype.dialogId;
    delete DialogContent.prototype.state;
    delete DialogContent.prototype.onClose;
    delete DialogContent.prototype.isModal;
    delete DialogContent.prototype.destroy;
    DialogFrame.prototype.constructor = DialogFrame;

    DialogFrame.prototype.destroy = function () {
        var self = this;
        setTimeout(function () {
            BaseDialog.prototype.destroy.call(self);
        }, 150);

    };
    DialogFrame.prototype.bindPublicEvents = function () {
        //todo
    };
    //----------------------------------------------------------------------------------------------------------------------------	
    function _contentDialog(settings) {

        var dialog = new DialogContent(settings.width, settings.height, settings.title, settings.isModal, settings.content, settings.onClose, settings.padding, settings.zindex, settings.bindPublicEventsArray);
        var initDialogContentString = dialogContentCreateString.replace('{#title#}', dialog.title).
			replace("{#content#}", dialog.content).
			replace("{#height#}", dialog.height).
			replace("{#width#}", dialog.width).
			replace("{#zindex#}", dialog.zindex).
			replace("{#zindex-1#}", dialog.zindex - 1).
			replace(new RegExp('{#dialogId#}', 'g'), dialog.dialogId).replace('{#padding#}', dialog.padding);;
        $(initDialogContentString).appendTo(window.document.body);
        dialog.state = true;
        dialog.bindPrivateEvents();
        dialog.bindPublicEvents();
        dialog.makeDraggable();
        dialog.toCenter();
        instances.push(dialog);
        dialog.show();
        return dialog;
    }

    function _initFrameDialog(settings) {
        var dialog = new DialogFrame(settings.width, settings.height, settings.title, settings.isModal, settings.url, settings.frameScroll, settings.frameWidth, settings.frameHeight, settings.frameBorder, settings.bindPublicEventsArray, settings.onClose, settings.padding);
        var initDialogFrameString = dialogFrameCreateString.replace('{#title#}', dialog.title).
			replace("{#height#}", dialog.height).
			replace("{#width#}", dialog.width).
			replace(new RegExp('{#dialogId#}', 'g'), dialog.dialogId).
			replace('{#url#}', dialog.url).
			replace('{#frameScroll#}', dialog.frameScroll).
			replace('{#frameWidth#}', dialog.frameWidth).
			replace('{#frameHeight#}', dialog.frameHeight).
			replace('{#frameBorder#}', dialog.frameBorder).
			replace('{#padding#}', dialog.padding);

        $(initDialogFrameString).appendTo(window.document.body);
        dialog.state = true;
        dialog.bindPrivateEvents();
        dialog.bindPublicEvents();
        dialog.makeDraggable();
        dialog.toCenter();
        instances.push(dialog);
        dialog.show();
        return dialog;
    }
    //-----------------------------------------------------------------------------------------------------------------------------
    var methods = {
        contentDialog: function (settings) {
            settings = __extendSettingsForDialogContent(settings);
            return _contentDialog.call(this, settings);
        },
        frameDialog: function (settings) {
            settings = __extendSettingsForDialogFrame(settings);
            return _initFrameDialog.call(this, settings);
        }
    };

    $.Popup = function (method, options) {
        // Method calling logic
        if (methods[method]) {
            return methods[method].apply(this, Array.prototype.slice.call(arguments, 1));
        } else if (typeof method === 'object' || !method) {
            return methods.init.apply(this, arguments);
        } else {
            $.error('Method ' + method + ' does not exist on jQuery');
        }
    };
})(jQuery);