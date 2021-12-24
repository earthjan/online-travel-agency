"use strict";
// document.getElementById("departure-datetime").min = min;

// Formats the date object into "yyyy-mm-ddThh:mm" format.
function formatDate(dateObject) {
    let newFormat = dateObject.getFullYear() +
        "-" + dateObject.getMonth() +
        "-" + dateObject.getDate() +
        "T" + dateObject.getHours() +
        ":" + dateObject.getMinutes();
    return newFormat;
}

// Gets next week from the current date and time
function getNextWeek() {
    let now = new Date();
    return new Date(firstDay.getTime() + 7 * 24 * 60 * 60 * 1000);
}

// Gets the input values from the Modal, and passes
// to the form inputs for flight query.
// Statements for bags are uncertainly removed to migrate 
// bag form controls to the 3rd process page passenger form.
function modalInputValues() {
    let adult = getInputValue("adult_modal"),
        child = getInputValue("child_modal"),
        infant = getInputValue("infant_modal");
    // cabin_bag = getInputValue("cabin_bag_modal"),
    // checked_bag = getInputValue("checked_bag_modal");

    let passengerSum = Number(adult) + Number(child) + Number(infant);
    //bagSum = Number(cabin_bag) + Number(checked_bag);

    setInputValue("adult", adult);
    setInputValue("child", child);
    setInputValue("infant", infant);
    // setInputValue("cabin_bag", cabin_bag);
    // setInputValue("checked_bag", checked_bag);
    setElementText("passengerNumbersValue", passengerSum);
    // setElementText("bagsValue", bagSum);    
}

function getInputValue(id) {
    return document.getElementById(id).value;
}

function setInputValue(id, value) {
    document.getElementById(id).value = value;
}

function getElementText(id) {
    return document.getElementById(id).textContent;
}

function setElementText(id, value) {
    return document.getElementById(id).textContent = value;
}

// Increments the "number" type form control up to 5. 
// Beyond 5, the button is disabled.
function increment(formControlID, btnDecID, btnIncID, max) {
    let formControl = Number(getInputValue(formControlID));
    document.getElementById(btnDecID).disabled = false;

    if (formControl > max - 1) {
        document.getElementById(btnIncID).disabled = true;
    } else {
        setInputValue(formControlID, formControl + 1);
    }
}

// Decrements the "number" type form control up to 0. 
// Less than 0, the button is disabled.
function decrement(formControlID, btnDecID, btnIncID, min) {
    let formControl = Number(getInputValue(formControlID));
    document.getElementById(btnIncID).disabled = false;

    if (formControl < min + 1) {
        document.getElementById(btnDecID).disabled = true;
    } else {
        setInputValue(formControlID, formControl - 1);
    }
}

// Ensures that the user fill up one of the forms
// in the "Password or ID expiry" section.
// hasExpiryID is the date form that indicates the password's expiration date.
// noExpiryID is the checkbox form that indicates the password's no expiration.
function validatePassIDExpiry(hasExpiryID, noExpiryID) {
    let hasExpiry = (getInputValue(hasExpiryID) != ""),
        noExpiry = document.getElementById(noExpiryID).checked;

    if (hasExpiry) {
        document.getElementById(noExpiryID).required = false;
    } else if (noExpiry) {
        document.getElementById(hasExpiryID).required = false;
    }
}

// Generates 6 digits code.
// This is mainly used for the payment method.
function generateCode(textID) {
    let code = Math.floor(Math.random() * Math.floor(999999));
    document.getElementById(textID).innerHTML = code;
}

/**
 * Sets both the hidden field value and the button text for origin.
 * 
 * @param {string} text 
 * The origin from the modal that corresponds to origin button form.
 */
function setOriginLocation(text) {
    setElementText("button_origin", text);
    setInputValue("origin", text);
}

/**
 * Sets both the hidden field value and the button text for destination.
 * 
 * @param {string} text 
 * The destination from the modal that corresponds to destination button form.
 */
 function setDestinationLocation(text) {
    setElementText("button_destination", text);
    setInputValue("destination", text);
}