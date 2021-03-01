<template>
    <div>
    <Home/>
  <b-card id="card"
    class="mb-2"
  >
 

 <div id="display" class="card" v-for="book in allBooks" :key="book._id">
        <div class="img">
          <img v-bind:src="book.bookImage" />
        </div>

        <div id="bookdiv" class="book">
          <div class="bookname"><b>{{ book.bookName }}</b></div>
          <div id="name">by {{  book.authorName }}</div> 
          <div id="price"><b>RS:</b> {{ book.bookPrice }}</div>
        </div>
 </div>
    <b-card-text>
     
     </b-card-text>

    <b-button id="button"  style="margin-top: 12%; float:right; position: relative" variant="primary">PLACE ORDER</b-button>
  </b-card>
</div>
</template>

<script>
import Home from "../components/Home"

export default {
    components:{
        Home,
    }
    
}
</script>

<style scoped>
#card{
    height: 40%;
    width: 40%;
    margin-left:16%;
    margin-top: 6%;
}

#button{
    height: 28px;
    padding:0%;
    width: 104px;
 border-radius:0px;
 outline: none;   
    font-size: 12px;
}

#image{
    display: flex;
    background-color: black;
    height:40% ;
    width: 30%;
}
/* 
#cart
{
     float:left;
     display: grid;
} */
</style>