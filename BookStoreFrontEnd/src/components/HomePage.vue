<template>
    <div>
<Home/>
    <router-view/>

<!-- <Book/> -->
    </div>
</template>

<script>
// import Book from "../components/Book"
 import Home from "../components/NavBar"

export default {
    components:{
        Home,
        // Book,
    }
}
</script>