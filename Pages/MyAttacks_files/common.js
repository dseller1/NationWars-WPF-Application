<!--

function jumpTo(url)
{	
	location.href=url;
}

function openHelpWindow(helptopic) {
	url = 'http://wiki.Nation-Wars.com/index.php?title='+ helptopic;
	target = 'wowHelpWindow';
	other = 'directories=no,height=400,width=650,location=no,menubar=no,resizable=no,scrollbars=yes,status=no,toolbar=no,top=200,left=150';
	o = window.open(url,target,other,false);
	o.focus();
	return o;
}

function OpenCboxWindow(helptopic) {
url = 'info.phptitle='+ helptopic;	
	target = 'wowHelpWindow';
	other = 'directories=no,height=400,width=650,location=no,menubar=no,resizable=no,scrollbars=yes,status=no,toolbar=no,top=200,left=450';
	o = window.open(url,target,other,false);
	o.focus();
	return o;
}

function OpenNationCboxWindow(helptopic) {
	url = 'nation_cbox.php';
	target = 'wowHelpWindow2';
	other = 'directories=no,height=400,width=650,location=no,menubar=no,resizable=no,scrollbars=yes,status=no,toolbar=no,top=200,left=150';
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


function OpenWarTimeWindow(helptopic) {
	url = 'wartimechart.php';
	target = 'wowHelpWindow3';
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




function openHelpWindowDirect(topic) {
	url = 'helpsearch.php?topic='+ topic;
	target = 'wowHelpWindow';
	other = 'directories=no,height=200,width=350,location=no,menubar=no,resizable=no,scrollbars=yes,status=no,toolbar=no,top=200,left=150';
	o = window.open(url,target,other,false);
	o.focus();
	return o;
}

function openGameStatsWindow(recordid,type,userlistid) {
	url = 'info.php';
	target = 'wowGameStatsWindow';
	other = 'directories=no,height=200,width=350,location=no,menubar=no,resizable=no,scrollbars=yes,status=no,toolbar=no,top=200,left=150';
	o = window.open(url,target,other,false);
	o.focus();
	return o;
}
 
function updateFramsetTitle(thetitle) {
	if (typeof(parent.document.title) == 'string') {
    	parent.document.title = thetitle;
	}
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

function confirmLink(theLink, message) {
	
    var is_confirmed = confirm(message);

    return is_confirmed;
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

function CheckBeforeLaunch(form) {

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