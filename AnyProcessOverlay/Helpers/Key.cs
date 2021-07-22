using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Any_Process_Overlay.Helpers
{
    class Key
    {
        private string keyName;
        private int keyId;
        private bool keyDown;

        public Key(int keyId, string keyName)
        {
            this.keyId = keyId;
            this.keyName = keyName;
        }

        public string Name
        {
            get
            {
                return keyName;
            }
        }

        public int Id
        {
            get
            {
                return keyId;
            }
        }

        public bool IsKeyDown
        {
            get
            {
                return keyDown;
            }
            set
            {
                keyDown = value;
            }
        }
    }
}
