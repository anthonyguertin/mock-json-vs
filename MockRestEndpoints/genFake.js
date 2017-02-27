var faker = require('faker')
var jsf = require('json-schema-faker')
var fs = require('fs')

//console.log('faker is working')
console.log(faker.name.findName())
console.log(faker.internet.email())
console.log(faker.helpers.createCard())

var schema = {

    person: [
        {
            name: faker.name.findName(),
            email: faker.internet.email(),
            phone: faker.phone.phoneNumber()
        }
    
    ]
}
var sample = jsf(schema)
var util = require('util');
fs.writeFileSync('./data.json', util.inspect(sample), 'utf-8');


