var express = require('express');

var router = express.Router();



/*
GET - intro to APIs
*/
router.get('/apiDoc', function(req, res) {
	res.status(200).json([
		{"GET /flyer":" get all flyers"},
		{"GET /flyer/:id ":" get flyer by ID"},
		{"POST /flyer POST":" create flyer in db"},
		{"POST /ticket/:id ":" create new ticket in Blockchain and tie to flyer", payload: {"to":"cgn", "from":"jfk", "date":"2018-08-30T22:49:07.169Z"} },
		
		{"POST /luggage/:id/ticket/:ticket":" - add luggage to trip", payload: {"bag":{"w":1, "h":2, "l":3, "weight":4} }  },

	])

});



router.get('/getCityData', function(req, res) {
	


	/*
	return flyerModel.findById({_id: ObjectId(req.param('id'))})
	.then((f)=>{
		res.status(200).json(f);
	});
*/

});




router.post('/food/flyer/:id/ticket/:ticket', function(req, res) {
	/*
	var flyer;

	var msgCnt = 0;
	message(req, req.body.msgType ,{step:msgCnt++, complete: true})
	
	return flyerModel.findById({_id: ObjectId( req.param('id') )})
	.then((flyer)=>{
		message(req, req.body.msgType ,{step:msgCnt++})
		flyer.trips.id(req.param('ticket')).food.push( {food:req.body.food, id:req.body.id} );
		return flyer.save();

	})
	.then((f)=>{
		flyer = f;

		//if they user wants a beacon take the money from their account
		if(req.body.paid == 'true'){ 
			message(req, req.body.msgType ,{step:msgCnt++})

			sourceKeypair = StellarSdk.Keypair.fromSecret( flyer.reward.private ); //get public and private key from steller network
			var server = new StellarSdk.Server('https://horizon-testnet.stellar.org'); //connect to test net
			return server.loadAccount(flyer.reward.public)
			.then((account)=>{ // this is the account
				var transaction = new StellarSdk.TransactionBuilder(account) // from this account create a transaction
					.addOperation(StellarSdk.Operation.payment({
					destination: stellerPub,
					asset: StellarSdk.Asset.native(),
					amount: '100',
				}))
				.addMemo(StellarSdk.Memo.text('Flight Food'))
				.build();

				transaction.sign(sourceKeypair); //sign the transaction with the private key of the user
				transaction.toEnvelope().toXDR('base64');

				return server.submitTransaction(transaction); //submit the transaction to steller network
					
			})
			.then((tx)=>{ // after transaction is done
				console.log(tx);
				stellerTx = tx;
				message(req, req.body.msgType ,{step:msgCnt++})

				return server.loadAccount(flyer.reward.public) //load the account we added funds to
			})
			.then((account)=>{
				message(req, req.body.msgType ,{step:msgCnt++, complete: true})

				flyer.reward.balance = account.balances[0].balance; //get the balance and update in Mongo (Performance reasons) 
				
				return flyer.save();
			})

		}else { 
			return flyer.save();
		}

	})
	.then((f)=>{
		res.status(200).json( f );

	});
*/
})


module.exports = router;














