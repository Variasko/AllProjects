package com.example.myapplication.retrofit

import java.time.temporal.TemporalAmount

data class Product(
    val product: String,
    val wh: String,
    val amount: Int
)
data class Sklads(
    var sklads: List<Product>
)

data class User(
    val id: Int,
    val login: String,
    val password: String
)
data class Users(
    val users: List<User>
)