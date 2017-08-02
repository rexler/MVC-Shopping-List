function ListItemDeleted(elem) {
    if (elem.success) {
        $(".manage-list-item[data-item-id='" + elem.id + "']").remove();
        console.log("Item deleted");
    }
    else {
        console.log("Error deleting item. " + elem.message);
    }
}

function ListShowAddItems(obj) {
    if (obj.success) {
        var list = $('<ul class="list-group">');
        obj.items.forEach(function (item) {
            $(list).append('<li class="list-group-item">' + item.Name + '</li>');
        });
        $('#searchResults').empty().append(list);
    }
    else {
        console.log("Error loading search items. " + obj.message);
    }
}

function searchItems(searchTerm) {
    $.getJSON("/ShoppingLists/SearchAddItemToList/?q=" + searchTerm, null, function (data) {
        ListShowAddItems(data);
    });
}
var timeout = null;
(function () {
    //event handlers
    var searchBox = $('.searchBox');
    $(searchBox).on('keyup', function () {
        clearTimeout(timeout);
        var searchVal = $(searchBox).val();

        if (searchVal) {
            timeout = setTimeout(function () {
                searchItems(searchVal)
            }, 1500);
        }
        else $('#searchResults').empty();
        
    });
})();

