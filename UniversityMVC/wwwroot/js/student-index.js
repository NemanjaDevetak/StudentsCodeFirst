$(document).ready(function () {
    $("#studentTable").DataTable(
        {
            "ajax": {
                "url": "/Student/Get",
                "type": "GET",
                "dataType": "json"
            },
            "columns": [
                { "data": "firstName" },
                { "data": "lastName" },
                { "data": "studentIndex" },
                {
                    "data": "studentIndex",
                    "bsort" : false,
                    "mRender": function (data, type, row) {
                        return "<a href='student/update?id=" + row.id + "'>EDIT</a>";
                    }
                }
            ]
        });
});