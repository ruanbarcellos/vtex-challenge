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
            var cartIcon = React.DOM.i({
                className: 'small mdi-action-add-shopping-cart'
            });
            var developerBuy = React.DOM.a({
                className: 'secondary-content',
                href: '',
                disabled: ''
            }, cartIcon);

            return (React.DOM.li({
                    className: 'collection-item avatar'
                }, developerAvatar,
                developerName,
                developerPrice,
                developerBuy));
        });

        return (React.DOM.ul({
            className: 'collection'
        }, rows));
    }
});
