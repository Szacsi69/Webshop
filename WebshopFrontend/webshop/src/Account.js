import userProfileImg from './img/user_icon.png';
import './css/account.css';

function Account() {
    return (
        <div className="container-fluid background-div">
            <div className="container form-container text-center mb-2">
                <h1 className="pb-3">Fiókom</h1>
                <div className="row">
                    <div className="col-xl-8">
                        <form action="" className="text-start pb-3">
                            <div className="mb-2">
                                <label for="name">Név</label>
                                <input type="text" name="name" id="name" className="form-control" />
                            </div>
                            <div className="mb-2">
                                <label for="gender">Nem</label>
                                <select name="gender" id="gender" className="form-control">
                                    <option value="male">Férfi</option>
                                    <option value="female">Nő</option>
                                </select>
                            </div>
                            <div className="mb-2">
                                <label for="email">Email cím</label>
                                <input type="text" name="email" id="email" className="form-control" />
                            </div>
                            <div className="mb-2">
                                <label for="telephone">Telefonszám</label>
                                <input type="text" name="telephone" id="telephone" className="form-control" />
                            </div>
                            <div className="mb-2">
                                <label for="country">Ország</label>
                                <input type="text" name="country" id="country" className="form-control" />
                            </div>
                            <div className="form-group">
                                <label for="region">Régió</label>
                                <input type="text" name="region" id="region" className="form-control" />
                            </div>
                            <div className="mb-4">
                                <label for="address">Utca, házszám</label>
                                <input type="text" name="address" id="address" className="form-control" />
                            </div>
                            <button type="submit" className="form-control custom-btn">Mentés</button>
                        </form>
                    </div>
                    <div className="col-xl-4">
                        <img src={userProfileImg} className="user-profile-pic" />
                        <small className="d-block">Felhasználónév</small>
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Account;