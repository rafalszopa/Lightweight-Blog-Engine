<template>
<div>
    <h1>Posts</h1>
    <table class="table">
        <tr>
            <th>Id</th>
            <th>Title</th>
            <th>Created on</th>
        </tr>
        <tr v-for="post in posts">
            <td>{{ post.id }}</td>
            <td>{{ post.title }}</td>
            <td>{{ post.createdOn }}</td>
        </tr>
    </table>
</div>
</template>

<script>
export default {
    data() {
        return {
            posts: null
        }
    },

    methods: {

    },

    async created() {
                try {
            let response = await this.$http.get('/api/Posts/Index')
            console.log(response.data);
            this.posts = response.data;
        } catch (error) {
            console.log(error)
        }
    }
}
</script>