$(document).ready(()=>{
    var valor = $("#txtLoginEmail").val();

    $("#txtLoginEmail").focus(()=>{
        if( $("#txtLoginEmail").val() == "" ||$("#txtLoginEmail").val() == valor )
        $("#txtLoginEmail").val("");
    });
    $("#txtLoginEmail").blur(()=>{
        if( $("#txtLoginEmail").val() == "")
            $("#txtLoginEmail").val(valor);
    });
});