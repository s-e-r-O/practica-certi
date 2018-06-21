var Client = require('node-rest-client').Client;
var fs = require('fs');
var async = require('async');

var obj = JSON.parse(fs.readFileSync('./JsonSamples.json', 'utf8'));
var client = new Client();

var body = {
    data: "",
    headers: { "Content-Type": "application/json" }
};

//product
async.each(obj.Product,function(product,callback) {
    body.data = product
    client.post("http://localhost:6064/api/product", body, function (data, response) {
    console.log("Product Posted");
    })
})

//category
async.each(obj.Category,function(category,callback) {
    body.data = category
    client.post("http://localhost:6064/api/category", body, function (data, response) {
    console.log("Category Posted");
    })
})

//store
async.each(obj.Store,function(store,callback) {
    body.data = store
    client.post("http://localhost:6064/api/store", body, function (data, response) {
    console.log("Store Posted");
    })
})

//users
async.each(obj.User,function(user,callback) {
    body.data = user
    client.post("http://localhost:6064/api/user", body, function (data, response) {
    console.log("User Posted");
    })
})


//shipping Addres
async.each(obj.ShippingAddress,function(shipAdd,callback) {
    body.data = shipAdd
    client.post("http://localhost:6064/api/shippingaddress", body, function (data, response) {
    console.log("Shipping Address Posted");
    })
})

//cart
async.each(obj.Cart,function(cart,callback) {
    body.data = cart
    client.post("http://localhost:6064/api/cart", body, function (data, response) {
    console.log("Cart Posted");
    })
})