function progress(percent, $element) {
    var progressBarWidth = percent * $element.width() / 100;
    var parentWidth = $element.parent().width();
    $element.find('div').animate({ width: progressBarWidth }, parentWidth).html(percent + "%&nbsp;");
}
/*
For using Progress Bar you have to do following:
Server Action
Pass a value in ViewModel like 
ViewModel
                            {
                                InstructionProgress = 80,
                            };

Create a div on client view like
<div class="">
        <div id="progressBar" class="tiny-green">
            <div>
            </div>
        </div>
    </div>


Call following in javascript
<script>
    $(document).ready(function () {
        progress($('#InstructionProgress').val(), $("#progressBar"));
    });
</script>
<script src="@Url.Content("~/Scripts/CardLeft-Progress.js")" type="text/javascript"></script>
*/