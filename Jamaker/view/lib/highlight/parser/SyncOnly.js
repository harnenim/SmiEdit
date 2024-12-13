SmiEditor.highlightText = function(text, state=null) {
	var previewLine = $("<span>");
	if (text.toUpperCase().startsWith("<SYNC ")) {
		previewLine.addClass("hljs-comment");
	}
	return previewLine.text(text);
}