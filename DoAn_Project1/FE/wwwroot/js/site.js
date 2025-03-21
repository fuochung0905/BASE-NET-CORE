function closeWindow() { }

function showLoading(value) {
    if (value) {
        $.blockUI({
            message: '<div class="overlay"><i class="fas fa-3x fa-sync-alt fa-spin"></i><div class="text-bold pt-2">Đang tải dữ liệu...</div></div>'
        });
    }
    else {
        $.unblockUI();
    }
}

function showLoadingElement(value, id) {
    if (value) {
        $('#' + id).block({
            message: '<div class="overlay"><i class="fas fa-3x fa-sync-alt fa-spin"></i><div class="text-bold pl-2">Đang tải dữ liệu...</div></div>'
        });
    }
    else {
        $('#' + id).unblock();
    }
}

var Toast = Swal.mixin({
    toast: true,
    position: 'top-end',
    showConfirmButton: false,
    timer: 5000
});

function showSuccessNotify(message) {
    Toast.fire({
        icon: 'success',
        title: 'Thông báo',
        html: message
    });
}

function showErrorNotify(message) {
    Toast.fire({
        icon: 'error',
        title: 'Thông báo lỗi',
        html: message
    });
}

function showToast(message) {
    $(document).Toasts('create', {
        class: 'bg-info',
        title: 'Thông báo mới',
        subtitle: 'Từ ' + message.NguoiGui,
        body: message.Message
    });
}

function closePopUpSystem() {
    $('#modal-systemModal').modal('hide');
}

function openLicense() {
    var url = '/Account/ShowLicenseInfo';

    showModal(url, "sm");
}

function ChangePassword() {
    var url = '/TaiKhoan/ShowPopupChangePassword';

    showModal(url, "sm");
}

function ChangeProfile() {
    var url = '/TaiKhoan/ShowPopupChangeProfile';

    showModal(url, "lg");
}

//Kiểm tra selected multi trên grid
function checkMultiSelectInGrid(listSelected) {
    if (listSelected.length == 0) {
        showErrorNotify(noDataMessage);
        return false;
    }

    if (listSelected.length > 1) {
        showErrorNotify("Chỉ được chọn 1 dòng dữ liệu để xử lý!");
        return false;
    }

    return true;
}

function showModal(url, size) {
    var width = '30%';
    $(".k-window").addClass("topWindowNormal");
    if (size == 'md') { width = '50%'; }
    if (size == 'lg') { width = '70%'; }
    if (size == 'full') { width = '100%'; $(".k-window").addClass("topWindowFull"); $(".k-window").removeClass("topWindowNormal"); }

    var dialog = $("#popupWindowModal").data("kendoWindow");
    dialog.refresh({
        url: url,
        data: {
            documentUrl: decodeURI(url)
        }
    });
    dialog.setOptions({
        actions: ["close"],
        modal: true,
        width: width,
        draggable: false,
        resizable: false,
        maxHeight: '100%',
        open: function (e) {
            document.querySelector('body').classList.add('modal-open');
        },
        close: function (e) {
            document.querySelector('body').classList.remove('modal-open');
            $(this.element).empty();
        }
    });
    dialog.center().open();
}

function reloadModal(url) {
    var dialog = $("#popupWindowModal").data("kendoWindow");
    dialog.refresh({
        url: url,
        data: {
            documentUrl: decodeURI(url)
        }
    });
}

function hideModal() {
    $("#popupWindowModal").data("kendoWindow").close();
}