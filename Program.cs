using ZenithTask.Checkout;


var rule1 = new Rule('A', 2.50m);
var rule2 = new Rule('B', 2.00m);
var rule3 = new Rule('A', 7.00m, 3);

Rule[] rules = [rule1, rule2, rule3];

var checkout = new Checkout(rules);

checkout.Scan('A');
checkout.Scan('A');
checkout.Scan('A');

checkout.Scan('B');
checkout.Scan('2');

checkout.GetTotalPrice();