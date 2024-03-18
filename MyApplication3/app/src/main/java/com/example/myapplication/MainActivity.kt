package com.example.myapplication

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Adapter
import android.widget.ArrayAdapter
import android.widget.Button
import android.widget.ListView
import android.widget.TextView
import com.example.myapplication.retrofit.Product
import com.example.myapplication.retrofit.ProductApi
import com.example.myapplication.retrofit.Sklads
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val tv = findViewById<ListView>(R.id.list)
        val b = findViewById<Button>(R.id.button)


        val retrofit = Retrofit.Builder()
            .baseUrl("http://192.168.105.231:8000/")
            .addConverterFactory(GsonConverterFactory.create())
            .build()
        val productApi: ProductApi = retrofit.create(ProductApi::class.java)

        b.setOnClickListener {
            CoroutineScope(Dispatchers.IO).launch {
                val product: Sklads = productApi.getDog()
                runOnUiThread {
                    var a: ArrayList<String> = ArrayList<String>()

                    for (i in product.sklads){
                        a.add("'${i.product}': ${i.amount} шт на скалде - '${i.wh}'")
                    }

                    tv.adapter = ArrayAdapter(this@MainActivity, android.R.layout.simple_expandable_list_item_1, a)
                }
            }
        }
    }
}