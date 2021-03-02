<template>
  <div>
    <!-- <Home/> -->
    <b-card class="card">
    <div id="bookcount">
      <h5>My Cart</h5>
      ({{ allBooks.length }} <label id="lb">Items </label>)
    </div>
      <div id="display" v-for="book in allBooks" :key="book._id">
        <div class="img">
          <img v-bind:src="book.bookImage" />
        </div>

        <div id="bookdiv" class="book">
          <!-- <div class="bookname"> -->
            <b>{{ book.bookName }}</b>
          <!-- </div> -->
          <!-- <div id="name"> -->
          by {{ book.authorName }}
          <!-- </div> -->
          <!-- <div id="price"> -->
            <b>RS: {{ book.bookPrice }}</b>
          <!-- </div> -->
        </div>
      </div>
      <b-button
        id="button"
        style="margin-top: 12%; float:right; position: relative"
        variant="primary"
        >PLACE ORDER</b-button
      >
      <b-card-text> </b-card-text>

     
    </b-card>
  </div>
</template>

<script>
// import bookService from "../Services/bookService";
// import Description from './Description.vue';
export default {
  name: "DisplayBooks",
  // components: {Description},

  props: ["allBooks", "total"],

  data() {
    return {
      books: [],
      // total:'',
      Loadding: false,
      // bookId: "",
      // UserId:'',
      // bookCount: 1,
    };
  },
};
</script>

<style lang="scss" scoped>

#button{
 top: -110px;
    left: 2px;
    width: 140px;
    height: 29px;
    background: #3371B5 0% 0% no-repeat padding-box;
    border-radius: 2px;
    opacity: 1;
    font-size: 12px;
      text-align: center;
}
// Card
#display {
  margin-left: 8%;
  margin-top: 2%;
  // top: 400px;
  // left: 120px;
  width: 233px;
  // background: #f5f5f5 0% 0% no-repeat padding-box;
  border-radius: 2px 2px 0px 0px;
  opacity: 1;
  display: flex;
}

//Name Margin
.book {
  float: left;
  margin-left: 20px;
  background: #f5f5f5 0% 0% no-repeat padding-box;
}

.img {
top: 192px;
left: 213px;
width: 65px;
height: 85px;
// background: transparent url('img/Image 11.png') 0% 0% no-repeat padding-box;
opacity: 1;
}

#main-container {
  height: 80%;
  width: 80%;
  display: flex;
  flex-wrap: wrap;
  margin-left: 12%;
}


//Author NAme
#name {
  font-size: 12px;


  display: grid;
  margin-left: 8px;
}

#price {
  font-size: 12px;
  margin-left: 8px;
}



//Bookname Bg Color
#bookdiv {
  background-color: white;
  display: grid;
  text-align: left;
  font-size: 14px;
  margin-left: 18px;
  height: 10px;
 
  // word-break: break-all;

}


#bookcount {
  margin-top: -12px;
  margin-left: 8%;
font-size: small;
  display: flex;
}

#drop {
  background-color: white;
  display: flex;
  margin-left: 720px;
}

.card {
  position: relative;
  flex-direction: column;
  border-radius: 0.25rem;
  border: 1px solid #707070;
  height: 251px;
  top: 112px;
  left: 177px;
  width: 774px;
}

.card-body {
    flex: 1 1 auto;
    min-height: 1px;
    /* padding: 1.25rem; */
}
</style>
