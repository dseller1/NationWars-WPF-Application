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

function submitClickDisableAll(theForm)
{
	for (i=0;i<theForm.elements.length;i++)
	{
		theForm.elements[$i].disabled = true;
	}
}
function confirmClick(theLink, message) {		
    var is_confirmed = confirm(message);
    return is_confirmed;
}
function openHelpWindow(helptopic) {
	url = 'helpsearch.php?search='+ helptopic;
	target = 'wowHelpWindow';
	other = 'directories=no,height=200,width=350,location=no,menubar=no,resizable=no,scrollbars=yes,status=no,toolbar=no,top=200,left=150';
	o = window.open(url,target,other,false);
	o.focus();
	return o;
}
function openHelpWindowDirect(topic) {
	url = 'helpsearch.php?topic='+ topic;
	target = 'wowHelpWindow';
	other = 'directories=no,height=200,width=350,location=no,menubar=no,resizable=no,scrollbars=yes,status=no,toolbar=no,top=200,left=150';
	o = window.open(url,target,other,false);
	o.focus();
	return o;
}
function openGameStatsWindow(recordid,type,userlistid) {
	url = 'info.php;
	target = 'wowGameStatsWindow';
	other = 'directories=no,height=200,width=350,location=no,menubar=no,resizable=no,scrollbars=yes,status=no,toolbar=no,top=200,left=150';
	o = window.open(url,target,other,false);
	o.focus();
	return o;
}

function OpenNationIrcWindow(helptopic) {
	url = 'nationirc.php';
	target = 'wowHelpWindow4';
	other = 'directories=no,height=400,width=650,location=no,menubar=no,resizable=no,scrollbars=yes,status=no,toolbar=no,top=200,left=150';
	o = window.open(url,target,other,false);
	o.focus();
	return o;
}

function OpenInfoWindow(helptopic) {
	url = 'info.php';
	target = 'wowHelpWindow44';
	other = 'directories=no,height=400,width=650,location=no,menubar=no,resizable=no,scrollbars=yes,status=no,toolbar=no,top=200,left=150';
	o = window.open(url,target,other,false);
	o.focus();
	return o;
}
 
function updateFramsetTitle(thetitle) {
	if (typeof(parent.document.title) == 'string') {
    	parent.document.title = thetitle;
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

function updateDealValue(frm) {
	//var a;
	//var b;
	//a = round(frm.package_value.value)+round(frm.elements['mil_1'].value);
	//b = 'a'+inttostr(a)+'a';
	var packet_value = parseInt(frm.package_value.value);
	packet_value = 0;
	for (i=1;i<8;i++) {
		packet_value += parseInt(frm.elements['mil_'+i].value);
	}
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

function confirmLink(theLink, message) {
	
    var is_confirmed = confirm(message);

    return is_confirmed;
}
function JoeTecBetweenAds(x){
	x='http://joetec.net/adserv/between3.php?User_Id=25&img=URLTOYOURLOGO&height=HEIGHTOFYOURLOGOMUSTBELESSTHAN61&width=WIDTHOFYOURLOGO&url='+escape(x);
	return x
}

function reverse(str) {
	var reversedstr = "";
	var strArray;
	strArray = str.split("");
	
	for(var i = str.length -1 ; i >= 0 ; i--) {
		reversedstr += strArray[i];
	}
	return reversedstr;
}

function FormatNumbers(a) {
	var tmp;
	var tmp2 = '';
	tmp = reverse(a+'').split("");
	for (i=0;i<tmp.length;i++){
		if ((i%3 == 0) && (i > 0)) {
			tmp2 += '.';	
		}
		tmp2 += tmp[i];		
	}
	tmp2 = reverse(tmp2);
	return tmp2;
}

function PublicMarketCheckBeforeBuy(form,goods,amount,price,money) {
	purchaseAmount = form.elements['purchaseAmount'].value;
	if (amount == 0) {		
		window.alert('No '+goods+' are currently available');	
		return false;	
	}
	else if (purchaseAmount <= 0) {
		window.alert('You did not select any '+goods+' to buy!');
		return false;			
	}
	else if (purchaseAmount > amount) {		
		window.alert('Not enough '+ goods +' for sale at $'+FormatNumbers(price));
		return false;
	}
	else if (purchaseAmount*price > money) {
		window.alert('You cannot afford to buy that many '+goods+', the total cost would be $'+FormatNumbers(purchaseAmount*price)+' and you have $'+FormatNumbers(money));	
		return false;
	}
	else {
		if (confirmLink(form,'Do you want to purchase '+FormatNumbers(purchaseAmount)+' '+goods+' with a total cost of $'+FormatNumbers(purchaseAmount*price)+'?')) {
			return submitClick(form);
		}
		else {
			return false;
		}
 	}
}

function PublicMarketCheckBeforeSale(form) {
	if (confirmLink(form,'Do you want to send the goods to the Public Market?')) {
		return submitClick(form);
	}
	else {
		return false;
	}
}

function PublicMarketCheckBeforeBringBack(form) {
	var haschecked = false;
	for (var i=0;i<form.elements.length;i++) {
		var e = form.elements[i];
		if ((e.type=='checkbox') && !e.disabled && e.checked) {
			haschecked = true;
		}	
	}
	if (haschecked == false) {
		return false;
	}
	else if (confirmLink(form,'Do you want to retrieve the selected goods from the market?')) {
		return submitClick(form);
	}
	else {
		return false;
	}
}

function DestroyCheckBeforeDestroy(form) {

	if (confirmLink(form,'Are you sure you want to destroy these buildings?')) {

		return submitClick(form);

	}

	else {

		return false;

	}


}

function DestroyCheckBeforeLaunch(form) {

	if (confirmLink(form,'Are you sure you want to start a Nuclear War?')) {

		return submitClick(form);

	}

	else {

		return false;

	}


}





function CheckbeforeChange(form) {

	if (confirmLink(form,'Are you sure you want to change your Tax/Draft Rate to this?')) {

		return submitClick(form);

	}

	else {

		return false;

	}


}

function LaunchNewResizableWindow(url,windowName,width,height) {
	window.open (url,windowName,"width="+ width +",height="+ height +",location=0,menubar=0,resizable=1,scrollbars=0,status=0,titlebar=0,toolbar=0,screenX=100,left=100,screenY=30,top=60");
}

-->