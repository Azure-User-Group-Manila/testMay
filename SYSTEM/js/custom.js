      $(".select2").select2({ placeholder: "Select a State", maximumSelectionSize: 6 });

            $(":checkbox").on("click", function () {
                $(this).parent().nextAll("select").select2("enable", this.checked);
            });

            $("#demonstrations").select2({ placeholder: "Select2 version", minimumResultsForSearch: -1 }).on("change", function () {
                document.location = $(this).find(":selected").val();
            });

            $("button[data-select2-open]").click(function () {
                $("#" + $(this).data("select2-open")).select2("open");
            });



            (function ($) {
                $(document).ready(function () {
                    $('ul.dropdown-menu [data-toggle=dropdown]').on('click', function (event) {
                        event.preventDefault();
                        event.stopPropagation();
                        $(this).parent().siblings().removeClass('open');
                        $(this).parent().toggleClass('open');
                    });
                });
            })(jQuery);