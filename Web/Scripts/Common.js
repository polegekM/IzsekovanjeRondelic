InputFieldsValidation = function (gridLookupItems, inputFields, dateFields, memoFields, comboBoxItems, tokenBoxItems) {
    var procees = true;

    if (gridLookupItems != null) {
        for (var i = 0; i < gridLookupItems.length; i++) {
            var item = gridLookupItems[i];

            if (item.GetText() == null || item.GetText() == "Izberi... " || item.GetText() == "" || item.GetText() == "Izberi...  -  - " || item.GetText() == "Izberi...") {
                $(item.GetInputElement()).parent().parent().addClass("focus-text-box-input-error");
                procees = false;
            }
            else
                $(item.GetInputElement()).parent().parent().removeClass("focus-text-box-input-error");
        }
    }

    if (inputFields != null) {
        for (var i = 0; i < inputFields.length; i++) {

            var item = inputFields[i];
            if (item.GetText().trim() == "") {
                $(item.GetInputElement()).parent().parent().parent().addClass("focus-text-box-input-error");
                procees = false;
            }
            else
                $(item.GetInputElement()).parent().parent().parent().removeClass("focus-text-box-input-error");
        }
    }

    if (dateFields != null) {
        for (var i = 0; i < dateFields.length; i++) {

            var item = dateFields[i];
            if (item.GetValue() == null) {
                $(item.GetInputElement()).parent().parent().addClass("focus-text-box-input-error");
                procees = false;
            }
            else
                $(item.GetInputElement()).parent().parent().removeClass("focus-text-box-input-error");
        }
    }

    if (memoFields != null) {
        for (var i = 0; i < memoFields.length; i++) {

            var item = memoFields[i];
            if (item.GetText() == "") {
                $(item.GetInputElement()).parent().addClass("focus-text-box-input-error");
                procees = false;
            }
            else
                $(item.GetInputElement()).parent().removeClass("focus-text-box-input-error");
        }
    }

    if (comboBoxItems != null) {
        for (var i = 0; i < comboBoxItems.length; i++) {
            var item = comboBoxItems[i];
            if (item.GetSelectedItem() == null || item.GetSelectedItem().text == "Izberi... ") {
                $(item.GetInputElement()).parent().parent().addClass("focus-text-box-input-error");
                procees = false;
            }
            else
                $(item.GetInputElement()).parent().parent().removeClass("focus-text-box-input-error");
        }
    }

    if (tokenBoxItems != null) {
        for (var i = 0; i < tokenBoxItems.length; i++) {

            var item = tokenBoxItems[i];
            if (item.GetTokenCollection().length <= 0) {
                $(item.GetInputElement()).parent().parent().parent().addClass("focus-text-box-input-error");
                procees = false;
            }
            else
                $(item.GetInputElement()).parent().parent().parent().removeClass("focus-text-box-input-error");
        }
    }

    return procees;
};