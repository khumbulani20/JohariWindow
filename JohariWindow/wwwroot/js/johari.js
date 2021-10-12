var dataTable;

$(document).ready(function () {
    loadList();
});

function loadList() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/client",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { data: "firstName", width: "40%" },
            { data: "lastName", width: "40%" },
            
            {
                data: "id", width: "30%",
                "render": function (data) {
                    return `<div class="text-center">

                            <a href="/Admin/Johari?id=${data}"
                            class ="btn btn-success text-white style="cursor:pointer; width=100px;"> <i class="far fa-edit"></i>Run Johari</a>

                            <a onClick=Delete('/api/client/'+${data})
                            class ="btn btn-danger text-white style="cursor:pointer; width=100px;"> <i class="far fa-trash-alt"></i>Delete</a>

                    </div>`;
                }
            }
        ],
        "language": {
            "emptyTable": "no data found."
        },
        "width": "100%"
    });
    //pass client id to johari window to use for running the johari
}

function Delete(url) {
    //sweet alert 
    swal({
        title: "Are you sure want to delete ?",
        text: "Once deleted, you will not be able to recover this  data!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else
                        toastr.error(data.message);
                }

            })
        }
    });
}