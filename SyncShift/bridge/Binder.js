function Binder(editor) {
	var _ = this._ = editor;
	
	this.focus = function(target) {
		_.focusWindow(target);
	}
	
	var init = false;
	this.initAfterLoad = function() {
		if (this.init) return;
		this.init = true;
		_.initAfterLoad();
	}

	this.showDragging = function(id) {
		_.showDragging(id);
	}
	this.hideDragging = function() {
		_.hideDragging();
	}

	this.alert   = function(target, msg) { _.alert  (target, msg); }
	this.confirm = function(target, msg) { _.confirm(target, msg); }
	this.prompt  = function(target, msg) { _.prompt (target, msg); }
}