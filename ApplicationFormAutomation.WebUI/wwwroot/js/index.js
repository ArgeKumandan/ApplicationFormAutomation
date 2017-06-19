$(document).ready(function () {
    $('#contact_form').bootstrapValidator({
        // To use feedback icons, ensure that you use Bootstrap v3.1.0 or later
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            first_name: {
                validators: {
                    stringLength: {
                        min: 2,
                    },
                    notEmpty: {
                        message: 'Lütfen adınızı belirtiniz'
                    }
                }
            },
            last_name: {
                validators: {
                    stringLength: {
                        min: 2,
                    },
                    notEmpty: {
                        message: 'Lütfen soyadınızı belirtiniz'
                    }
                }
            },
            email: {
                validators: {
                    notEmpty: {
                        message: 'Lütfen e-posta adresinizi giriniz'
                    },
                    emailAddress: {
                        message: 'Lütfen geçerli bir e-posta giriniz'
                    }
                }
            },
            phone: {
                validators: {
                    notEmpty: {
                        message: 'Lütfen telefon numaranızı belirtiniz'
                    },
                    phone: {
                        country: 'TR',
                        message: 'Lütfen geçerli bir telefon numarası belirtiniz'
                    }
                }
            },
            gsm: {
                validators: {
                    notEmpty: {
                        message: 'Lütfen Cep Telefonu belirtiniz'
                    },
                    phone: {
                        country: 'TR',
                        message: 'Lütfen geçerli bir cep telefonu belirtiniz'
                    }
                }
            },
            address: {
                validators: {
                    stringLength: {
                        min: 8,
                    },
                    notEmpty: {
                        message: 'Lütfen adresinizi seçiniz'
                    }
                }
            },
            city: {
                validators: {
                    stringLength: {
                        min: 4,
                    },
                    notEmpty: {
                        message: 'Please bulunduğunuz ili seçiniz'
                    }
                }
            },
        }
    })
        .on('success.form.bv', function (e) {
            $('#success_message').slideDown({ opacity: "show" }, "slow") // Do something ...
            $('#contact_form').data('bootstrapValidator').resetForm();

            // Prevent form submission
            e.preventDefault();

            // Get the form instance
            var $form = $(e.target);

            // Get the BootstrapValidator instance
            var bv = $form.data('bootstrapValidator');

            // Use Ajax to submit form data
            $.post($form.attr('action'), $form.serialize(), function (result) {
                console.log(result);
            }, 'json');
        });
});