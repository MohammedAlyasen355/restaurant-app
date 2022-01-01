// JavaScript source code
$(document).ready(function () {

    'use strict';

    $('[placeholder]').focus(function () {
        $(this).attr('data-text', $(this).attr('placeholder'));
        $(this).attr('placeholder', '');
    }).blur(function () {
        $(this).attr('placeholder', $(this).attr('data-text'));
    })
    // $('input').each(function(){
    // 	if ($(this).attr('required') === 'required'){
    // 		$(this).after('<div class = "asterisk" > * </div> ');
    // 	}
    // })

    $('.confirm').click(function () {
        return confirm('Are You Sure ?!');
    })

    $("body").css("opacity", "1");
    var indexTitle = "If you are hangry ,You have the right site for <h5> you </h5> (^_^) ";
    var index = 0;
    var str = "";
    window.setInterval(function () {
        if (index == indexTitle.length) {
            return;
        }
        str += indexTitle[index];
        $("#index-title").html(str);
        index++;
    }, 100);

});

/*******************
** Help Functions **
*******************/

//
//this function cancel all charset except digit
//

function checkAge() {
    if (event.keyCode < 48 || event.keyCode > 57) {
        alert("Can`t write letters Just digit ");
        event.returnValue = false;
    }
}

function calCost() {
    var x1 = parseFloat(document.getElementById('price').value);
    var x2 = parseFloat(document.getElementById('num').value);
    var x3 = x1 * x2;
    document.getElementById('cost').value = x3;
}
function out($text) {
    alert($text);
}