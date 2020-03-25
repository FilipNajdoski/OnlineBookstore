// Wait for the DOM to be ready
$(function () {
    // Initialize form validation on the book create form.
    // It has the name attribute "bookcreate"
    $("form[name='bookcreate']").validate({
        success: "valid",
        // validation as we type data in the fields
        onkeyup: true,
        // add css error class
        errorClass: "error",
        // focus field when invalid
        focusInvalid: true,
        // highlight filds when error
        highlight: function (element, errorClass) {
            $(element).fadeOut(function () {
                $(element).fadeIn();
                $(element).addClass(errorClass);
            });
        },
        // Specify validation rules
        rules: {
            // The key name on the left side is the name attribute
            // of an input field. Validation rules are defined
            // on the right side
            Title: {
                required: true,
                minlength: 2
            },
            YearOfIssue: "required",
            NumberOfPages: {
                required: true,
                number: true,
                digits: true,
                min: 10
            },
            Genre: "required",
            CategoryID: {
                required: true,
                min: 1
            },
            AuthorID: {
                required: true,
                min: 1
            },
            PublisherID: {
                required: true,
                min: 1
            },
            Price: {
                required: true,
                number: true,
                digits: true
            },
            BookType: "required",
            Copies: {
                required: true,
                number: true,
                digits: true
            },
            Dimensions: "required",
            Edition: {
                required: true,
                number: true,
                digits: true,
                min: 1
            },
            Language: "required",
            Shipping: "required",
            Weight: {
                required: true,
                number: true,
                digits: true
            },
            Country: "required",
            Description: "required"
        },
        // Specify validation error messages
        messages: {
            Title: {
                required: "Please enter your firstname",
                minlength: jQuery.validator.format("At least {0} characters required!")
            },
            YearOfIssue: "Please enter your lastname",
            NumberOfPages: {
                required: "Please enter number of pages",
                number: "Please enter numbers only",
                digits: "Only digits are allowed in this field",
                min: jQuery.validator.format("At least number {0} required!")
            },
            Genre: "Please enter genre of the book",
            CategoryID: {
                required: "Please choose category",
                min: "Please select one category from the dropdown"
            },
            AuthorID: {
                required: "Please choose author",
                min: "Please select one author from the dropdown"
            },
            PublisherID: {
                required: "Please choose publisher",
                min: "Please select one publisher from the dropdown"
            },
            Price: {
                required: "Please enter the price of the book",
                number: "Please enter numbers only",
                digits: "Only digits are allowed in this field"
            },
            BookType: "Please enter book type",
            Copies: "Please enter number of copies",
            Dimensions: "Please enter dimensions of the book",
            Edition: {
                required: "Please enter edition number",
                number: "Please enter numbers only",
                digits: "Only digits are allowed in this field",
                min: jQuery.validator.format("At least number {0} required")
            },
            Language: "Please enter book language",
            Shipping: "Please enter shipping",
            Weight: "Please enter book weight",
            Country: "Please enter country of origin",
            Description: "Please enter description"
        },
        // Make sure the form is submitted to the destination defined
        // in the "action" attribute of the form when valid
        submitHandler: function (form) {
            form.submit();
        }
    });
});