<!--

function submitClick(theForm) {
	if (theForm.elements['Submit'].disabled == true) {
		return false;
	}
	else {
		theForm.elements['Submit'].value = "Loading...";
		theForm.elements['Submit'].disabled=true;
		return true;
	}
	
}

function confirmClick(theLink, message) {		
    var is_confirmed = confirm(message);
    return is_confirmed;
}

function submitClickDisableAll(theForm)
{
	for (i=0;i<theForm.elements.length;i++)
	{
		theForm.elements[$i].disabled = true;
	}
}

function checkAll(thecheckbox,frm) {
	if (thecheckbox.checked == true) {
		for (var i=0;i<frm.elements.length;i++) {
			var e = frm.elements[i];
			if ((e.type=='checkbox') && !e.disabled) {
				e.checked =	true;
			}
		
		}
	}
	else {
		for (var i=0;i<frm.elements.length;i++) {
			var e = frm.elements[i];
			if ((e.type=='checkbox') && !e.disabled) {
				e.checked =	false;
			}
		
		}
	}
}

function switchSelectBoxValue(theSource,theTarget) {
	theTarget.value = theSource.options[theSource.selectedIndex].value;
}


function selectRadio(theradio) {
	theradio.checked = true;
}

function submitForm1Arg(form,name,value) {
	document.forms[form].elements[name].value = value;
	document.forms[form].submit();

}

function submitForm(form) {
	document.forms[form].submit();
}


function verifyInput(input)
{
	/*
		Courtesy of Warl0rd
	*/
	last_char=input.substr((input.length)-1,1);
	if(last_char=="k")
		return input=input.substr(0,(input.length)-1)*1000;
	else if(last_char=="m")
		return input.substr(0,(input.length)-1)*1000000;
	else if(last_char=="b")
		return input.substr(0,(input.length)-1)*1000000000;
	else 
		return input;
}
-->