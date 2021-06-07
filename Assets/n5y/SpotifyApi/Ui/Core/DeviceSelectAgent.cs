using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;

namespace n5y.SpotifyApi.Ui.Core
{
    public class DeviceSelectAgent : AgentBase {
        readonly IObservable<DeviceTuple> onDeviceSelect;
        public DeviceSelectAgent(IObservable<DeviceTuple> onDeviceSelect) {
            this.onDeviceSelect = onDeviceSelect;
        }
    }
}
