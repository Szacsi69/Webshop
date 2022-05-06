import aboutUsImg from './img/about_us.png';
import './css/about-us.css';

function AboutUs() {
    return (
        <div class="container-fluid about-us">
            <div class="row">
                <div class="col-xl-4">
                    <img src={aboutUsImg}/>
                </div>
                <div class="col-xl-5 pr-2">
                    <h2>Rólunk:</h2>
                    <p>
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque mattis fermentum mattis. Praesent id accumsan neque. Donec eros tortor, tempor ac condimentum a, dignissim ac tellus. Sed maximus auctor justo, vitae euismod risus convallis quis. In venenatis laoreet nulla a convallis. Cras fermentum efficitur lacus, ut ornare urna. Cras laoreet, leo sit amet venenatis iaculis, diam elit iaculis felis, et dignissim orci sem in orci. Suspendisse mauris elit, luctus posuere sodales vitae, aliquet eu orci. Fusce in nibh vitae lacus blandit faucibus. Vestibulum rhoncus eleifend eros at ullamcorper. Maecenas nibh ligula, dictum quis nulla vel, iaculis vestibulum ante. In ultrices malesuada vehicula. Maecenas sit amet metus eget ligula tempor venenatis. Curabitur pellentesque eleifend ex, eget pharetra sapien rutrum et. Suspendisse pharetra magna sed orci dignissim, id sagittis lectus pharetra.
                        Mauris quis ligula in turpis aliquet vestibulum et in tellus. Sed ultricies laoreet interdum. Nullam sit amet orci justo. Cras in rhoncus odio. Pellentesque a ipsum ut lorem eleifend tristique. Nulla hendrerit risus nec velit ultrices, sed lobortis mauris hendrerit. Integer ac nunc sit amet libero bibendum maximus porta et dolor.
                        Vivamus sollicitudin eu arcu eleifend elementum. Curabitur luctus tincidunt orci nec mattis. Donec tortor tortor, porttitor vitae cursus sit amet, scelerisque sit amet justo. Nulla sed purus ac ex lobortis commodo. Curabitur nunc quam, rhoncus non magna in, aliquet tristique nulla. Duis pulvinar congue luctus. Nunc consectetur elementum quam, quis semper dui congue in. Nulla viverra mi in lacinia euismod. Vivamus id semper quam. Phasellus lacus enim, volutpat eu ornare vitae, fringilla ut justo. Mauris vitae nibh nisi. Nullam tincidunt efficitur purus, auctor blandit libero maximus faucibus.
                        Etiam mi ex, imperdiet ut convallis vitae, consectetur eget ipsum. Nullam scelerisque tortor at posuere laoreet. Cras vitae facilisis enim. Donec eleifend pellentesque ipsum, sed consectetur ligula aliquet vitae. Maecenas mauris lorem, aliquet sit amet sapien at, consectetur mattis metus. Donec faucibus consequat feugiat. Fusce efficitur, lorem quis interdum auctor, erat sapien interdum augue, non varius leo erat sed elit.
                        Aliquam a arcu sapien. Curabitur dignissim gravida orci, ac mollis quam. Sed lobortis laoreet elit eget vestibulum. Fusce vulputate risus sapien, eget lobortis dolor consequat et. Vestibulum fermentum diam nibh, non posuere sapien ornare vel. Donec ac tellus justo. Quisque at ex sed tortor porttitor tristique.
                    </p>
                </div>
                <div class="d-flex flex-column align-items-center reachability-container rounded col-xl-3">
                    <h2 class="pt-4">Elérhetőségek:</h2>
                    <ul class="font-weight-bold">
                        <li>Tel.: 06201234567</li>
                        <li>Email: email@email.com</li>
                        <li>Cím: 1234 Belrum Kő utca 11</li>
                    </ul>
                    <p>
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque mattis fermentum mattis. Praesent id accumsan neque. Donec eros tortor, tempor ac condimentum a, dignissim ac tellus. Sed maximus auctor justo, vitae euismod risus convallis quis. In venenatis laoreet nulla a convallis. Cras fermentum efficitur lacus, ut ornare urna. Cras laoreet, leo sit amet venenatis iaculis, diam elit iaculis felis, et dignissim orci sem in orci. Suspendisse mauris elit, luctus posuere sodales vitae, aliquet eu orci. Fusce in nibh vitae lacus blandit faucibus. Vestibulum rhoncus eleifend eros at ullamcorper. Maecenas nibh ligula, dictum quis nulla vel, iaculis vestibulum ante. In ultrices malesuada vehicula. Maecenas sit amet metus eget ligula tempor venenatis. Curabitur pellentesque eleifend ex, eget pharetra sapien rutrum et. Suspendisse pharetra magna sed orci dignissim, id sagittis lectus pharetra.
                        Mauris quis ligula in turpis aliquet vestibulum et in tellus.
                    </p>
                </div>
            </div>
        </div>
    );
}

export default AboutUs;