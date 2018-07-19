import CounterExample from 'components/counter-example'
import FetchData from 'components/fetch-data'
import HomePage from 'components/home-page'
import Posts from 'components/posts'
import Media from 'components/media'
import Tags from 'components/tags'

export const routes = [
    { path: '/', component: HomePage, display: 'Home', style: 'glyphicon glyphicon-home' },
    { path: '/posts', component: Posts, display: 'Posts', style: 'glyphicon glyphicon-th-list' },
    { path: '/media', component: Media, display: 'Media', style: 'glyphicon glyphicon-th-list' },
    { path: '/tags', component: Tags, display: 'Tags', style: 'glyphicon glyphicon-th-list' },
    { path: '/counter', component: CounterExample, display: 'Counter', style: 'glyphicon glyphicon-education' },
    { path: '/fetch-data', component: FetchData, display: 'Fetch data', style: 'glyphicon glyphicon-th-list' },
]