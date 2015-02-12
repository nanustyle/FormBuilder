define([
       'jquery', 'underscore', 'backbone'
       , "text!templates/app/tab-nav.html"

], function ($, _, Backbone,
           _tabNavTemplate) {
    return Backbone.View.extend({
        tagName: "div"
    , className: "tab-pane"
    , initialize: function (options) {
        this.options = options;
        this.id = this.options.title.toLowerCase().replace(/\W/g, '');
        this.tabNavTemplate = _.template(_tabNavTemplate);
        this.render();
    }
    , render: function () {
        // Render Snippet Views
        var that = this;
        if (that.collection !== undefined) {
            _.each(this.collection.renderAll(), function (snippet) {
                that.$el.append(snippet);
            });
        } else if (that.options.content) {
            that.$el.append(that.options.content);
        }
        // Render & append nav for tab
        $("#formtabs").append(this.tabNavTemplate({ title: this.options.title, showntitle:this.options.showntitle,id: this.id }))
        // Render tab
        this.$el.attr("id", this.id);
        this.$el.appendTo(".tab-content");
        this.delegateEvents();
    }
    ,initialGlobalVar:function(){
        //初始化全局变量


    }
    });
});
