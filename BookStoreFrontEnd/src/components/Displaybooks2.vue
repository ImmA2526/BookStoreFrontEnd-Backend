<template>
    
  <div class="maindiv">       
     <div id="bookcount"><h5>Books</h5>({{books.bookcount}})
<div class="dropdown">
                   
            </div></div>
            
             <!-- <div class="map-div" key={item._id}> -->
    <!-- <div id="main-container"> -->
<!-- //Card Div  -->
      <div id="cartdiv"  v-for="book in allBooks" :key="book._id">
       
                <div class="card" >
 <div class="imageDiv">
          <img v-bind:src="book.bookImage" />
        </div>
        <div class="cardBody" >
          <div class="bookname"><b>{{ book.bookName }}</b></div>
          <div class="bookname2">by {{  book.authorName }}</div> 
          <div class="bookname"><b>RS:</b> {{ book.bookPrice }}</div>
        </div>
        <div class="btns">
          <md-button type="button" id="addbag-btn">ADD TO BAG</md-button>
          <md-button type="button" id="wish-btn">WISHLIST</md-button>
        </div>
      </div>
    </div>
  </div>
    <!-- <card> -->
  <!-- </div> -->

</template>

<script>
export default {
  name: "DisplayBooks",
  components: {},

  props: ["allBooks"],

  data() {
    return {
      books: [],
      Loadding: false,
    };
  },
};
</script>

<style lang="scss" scoped>
.maindiv {
    display: flex;
    overflow-wrap: break-word;
    flex-wrap: wrap; 
    margin-right: 5%;
    margin-left: 13%;
    margin-top: 80px;
    
}
#cartdiv{
    display: flex;
    overflow-wrap: break-word;
    flex-wrap: wrap; 
    margin-right: 10%;
    margin-top: 50px;
}
.map-div{
    padding-left: 25px;
    display: grid;
}

#griddiv{
    display: grid;
}

.card {
    display: grid;
    height: 290px;
    border-radius: 10px;
    display: flex;
    margin-bottom: 20px;
    width: 220px;
    border-radius: 2px;
   
  }.card:hover {
    
    .discribe {
      opacity: 100%;
    }
}

.dropdown{
    margin-left:345px;  
}
#itemss{
    padding:0px
}

#dropdown-basic{
    color: #000;
    background-color: #ffffff;
    border-color: #000000;
    border-radius: 2px;
    font-size: small;
}
.dropdown-menu{
    font-size: small;
    padding: 10px;
    color: #212529;
    text-align: left;
    list-style: none;
    background-color: #fff;
    background-clip: padding-box;
    border: 1px solid rgba(0,0,0,.15);
    border-radius: .25rem;
    float: left;
    min-width: 8.5rem;
    z-index: 1000;
   
}

  .card-body{
      width: 200px;
      height: 200px;
  }
  .card-text{
    margin-top: -15px;
  }
.cart-btn{
    width: 80px;
    height: 50px;
}
.wish-btn{
    width: 80px;
    height: 50px;
}

.btn-div{
    display: flex;
    width: 204px;
    margin-top: 10px;
}

#addbag-btn {
    color: #fff;
    height: 33px;
    background-color: brown;
    border-color: brown;
    font-size: small;
    margin-right: 10px;
    margin-left: 12px;
    border-radius: 0px;
    #addbag-btn:hover{
        background-color: none;
    }    
}


#wish-btn{
    color: rgb(0, 0, 0);
    height: 33px;
    background-color: rgb(255, 255, 255);
    border-color: rgb(0, 0, 0);
    font-size: small;
    border-radius: 0px;
}
.imageDiv{
    display: flex;
    justify-content: center;
    background-color: #e9ecef;
}
img{
    vertical-align: middle;
    border-style: none;
    height: 145px;
    margin-top: 10px;
    margin-bottom: 10px;
}


.bookname{
    margin-left: 10%;   
}

.bookname2{
    margin-left: 10%;
    font-size: small;
    color: gray;
}

#bookCount{
    margin-left: 25px;
    margin-bottom: -35px;
}

.NV {
    display: none;
} 

.discribe{
    opacity: 0%;
}

#addedToBag{
    overflow: visible;
    
}


@media screen and (max-width: 800px) {
    .maindiv {
        display: flex;
        justify-content: center;
        overflow-wrap: break-word;
        flex-wrap: wrap; 
        margin-right: 10%;
        margin-left: 13%;
        margin-top: 80px;
        width: fit-content;
    }
    .dropdown{
        margin-left:0px;  
    }
    
    #cartdiv{
        display: flex;
        overflow-wrap: break-word;
        flex-wrap: wrap;
        justify-content: flex-end;
        justify-content: space-evenly;
        margin-top: 50px;
    }

    h5{
        font-size: 1rem;
    }
    input#serchbox {
        width: 166px;
        border-radius: 0px;
        margin-left: 0px;
        border-radius: 2px;
    }
    
    .cardContainer {
        display: grid;
        height: 290px;
        border-radius: 10px;
        display: flex;
        margin-bottom: 20px;
        width: 220px;
        border-radius: 2px;
       
      }
}
</style>
