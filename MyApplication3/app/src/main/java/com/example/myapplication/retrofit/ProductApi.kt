package com.example.myapplication.retrofit

import retrofit2.http.GET

interface ProductApi {
    @GET("/")
    suspend fun getDog(): Sklads

    @GET("/users")
    suspend fun getUsers(): Users


}