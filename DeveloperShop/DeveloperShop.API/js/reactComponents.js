var DeveloperList = React.createClass({
    displayName: 'DeveloperList',
    render: function () {

        var developers = this.props.data;

        var rows = developers.map(function (developer) {

            var developerAvatar = React.DOM.img({
                className: 'circle',
                src: developer.avatarUrl
            });
            var developerName = React.DOM.span({
                className: 'title'
            }, developer.name);
            var developerPrice = React.DOM.p(null, developer.price);

            return (React.DOM.li({
                    className: 'collection-item avatar'
                }, developerAvatar,
                developerName,
                developerPrice));
        });

        return (React.DOM.ul({
            className: 'collection'
        }, rows));
    }
});
